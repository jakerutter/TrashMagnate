using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;
    private Action<Item> useItemAction;
    private AudioManager _audio;

    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();

        itemList.Add(new Item { itemType = Item.ItemType.Can, amount = 20});
        itemList.Add(new Item { itemType = Item.ItemType.BrownGlassBottle, amount = 20});
        itemList.Add(new Item { itemType = Item.ItemType.SmallTire, amount = 20});
        itemList.Add(new Item { itemType = Item.ItemType.Box, amount = 20});
        itemList.Add(new Item { itemType = Item.ItemType.Pallet, amount = 20});
        itemList.Add(new Item { itemType = Item.ItemType.GreenGlassBottle, amount = 20});
        itemList.Add(new Item { itemType = Item.ItemType.Book, amount = 20});
        itemList.Add(new Item { itemType = Item.ItemType.Shoe, amount = 20});
        itemList.Add(new Item { itemType = Item.ItemType.PlasticJug, amount = 20});
    }

    public void AddItem(Item item)
    {
        //Debug.Log("AddItem called in Inv");
        if(item.IsStackable())
        {
            bool itemAlreadyInInventory = false;

            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    //Debug.Log("iterating item amount");
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                //Debug.Log("itemList .Add called in Inv");
                itemList.Add(item);
            }
        } 
        else 
        {
            itemList.Add(item);
        }
        if(OnItemListChanged != null)
        {
            //Debug.Log("OnItemListChanged is Invoked");
            OnItemListChanged.Invoke(this, EventArgs.Empty);
        } else 
        {
            //Debug.LogWarning("OnItemListChanged is null Inventory.cs ln 48");
        }
    }

    public void RemoveItem(Item item)
    {
        if(item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        } 
        else 
        {
            itemList.Remove(item);
        }
          if(OnItemListChanged != null)
        {
            OnItemListChanged.Invoke(this, EventArgs.Empty);
        }
    }

    public void UseItem(Item item)
    {
        useItemAction(item);
    }

    public void RecycleItem(Item item)
    {
        //get audio manager
        _audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        int requirement = item.RecycleRequirement();
        float mass = item.GetRawMass();
        RecyclingQuest.RawType rawType = item.GetItemRawType();
        bool stackable = item.IsStackable();
        int canHoldAmount = 0;
        bool canHoldAll = true;

        GameObject recyclerGameObject = GameObject.FindGameObjectWithTag("Recycler");

        if(recyclerGameObject == null){ Debug.Log("recyclerGameObject is null in RecycleItem"); }

        RecyclerWorld recWorld = recyclerGameObject.GetComponent<RecyclerWorld>();

        if(recWorld == null){ Debug.Log("recWorld is null in RecycleItem"); }

        Recycler rec = recWorld.GetRecycler();

         if(rec == null){ Debug.Log("rec is null in RecycleItem"); }

        float yield = rec.GetYield();
        //Debug.Log("Initial yield is "+ yield.ToString());

        float VariableYield = RecyclingInventory.GetVariableYield();
        //Debug.Log("Variable yield is "+ VariableYield.ToString());

        yield = yield * VariableYield;
        //Debug.Log("Final yield calculated to be "+ yield.ToString());

        //check item Recycle skill level
        if(requirement > RecyclingInventory.GetRecyclingSkill())
        {
            //send [failure] message saying cannot recycle
            Messenger messenger = GameObject.FindGameObjectWithTag("Messenger").GetComponent<Messenger>();
            messenger.SetMessage(Messenger.MessageType.Failure, "Insufficient skill for recycling this item.");
            return;
        }

        // check available inventory space against mass
        bool canHold = RecyclingInventory.HaveAvailableCapacity(mass * item.amount * yield);
        canHoldAll = canHold;
        //cant hold the entire stack of items
        if(!canHold && item.amount > 1)
        {
            if(RecyclingInventory.HaveAvailableCapacity(mass * yield))
            {
                //get the num of items player can recycle and still hold
                canHoldAmount = GetCanHoldAmount(item);
                canHold = true;
            }
        }

        //if there is enough room, add it
        if(canHold)
        {
            int recycleAmt = item.amount;
            
            if(canHoldAmount > 0)
            {
                recycleAmt = canHoldAmount;
            }

            //calculate waste and pollution
            float pollutionYield = RecyclingInventory.GetPollutionYield();
            //Pollution = item.mass * pollutionYield
            float pollution = mass * pollutionYield;
            //Waste = item.mass - (item.mass *  yield) + (item.mass * pollution)
            float waste = mass * RecyclingInventory.GetWasteYield();

            //set statics for pollution and waste
            // Debug.Log("pollution is " + pollution);
            // Debug.Log("waste is " + waste);

            RecyclingInventory.AddPollution(pollution);
            RecyclingInventory.AddWaste(waste);

            //play sound for item recycled (by type)
            if(rawType == RecyclingQuest.RawType.Paper)
            {
                float totalPaper = RecyclingInventory.GetPaperInventory();
                float newTotal = totalPaper + mass * recycleAmt * yield;
                RecyclingInventory.SetPaperInventory(newTotal);
                 //play sound
                _audio.Play("RecyclePaper");
            }
            else if(rawType == RecyclingQuest.RawType.Glass)
            {
                float totalGlass = RecyclingInventory.GetGlassInventory();
                float newTotal = totalGlass + mass * recycleAmt * yield;
                RecyclingInventory.SetGlassInventory(newTotal);
                //play sound
                _audio.Play("RecycleGlass");
            }
                else if(rawType == RecyclingQuest.RawType.Metal)
            {
                float totalMetal = RecyclingInventory.GetMetalInventory();
                float newTotal = totalMetal + mass * recycleAmt * yield;
                RecyclingInventory.SetMetalInventory(newTotal);
                //play sound
                _audio.Play("RecycleMetal");
            }
                else if(rawType == RecyclingQuest.RawType.Wood)
            {
                float totalWood = RecyclingInventory.GetWoodInventory();
                float newTotal = totalWood + mass * recycleAmt * yield;
                RecyclingInventory.SetWoodInventory(newTotal);
                 //play sound
                _audio.Play("RecycleWood");
            }
                else if(rawType == RecyclingQuest.RawType.Plastic)
            {
                float totalPlastic = RecyclingInventory.GetPlasticInventory();
                float newTotal = totalPlastic + mass * recycleAmt * yield;
                RecyclingInventory.SetPlasticInventory(newTotal);
                //play sound
                 _audio.Play("RecyclePlastic");
            }
                else if(rawType == RecyclingQuest.RawType.Rubber)
            {
                float totalRubber = RecyclingInventory.GetRubberInventory();
                float newTotal = totalRubber + mass * recycleAmt * yield;
                RecyclingInventory.SetRubberInventory(newTotal);
                //play sound
                 _audio.Play("RecycleRubber");
            }
                else if(rawType == RecyclingQuest.RawType.Electronic)
            {
                float totalElectronic = RecyclingInventory.GetElectronicInventory();
                float newTotal = totalElectronic + mass * recycleAmt * yield;
                RecyclingInventory.SetElectronicInventory(newTotal);
                //play sound
                 _audio.Play("RecycleElectronic");
            }
            
            RecyclingInventory.AdjustAvailableCapacity(mass);

            //if entire item was not recycled, remove item and replace with less items
            if(!canHoldAll)
            {
                //Debug.Log("recycling "+ canHoldAmount + " " + item.itemType);
                Item dupeItem = new Item { itemType = item.itemType, amount = item.amount };
                RemoveItem(item);
                AddItem(new Item { itemType = dupeItem.itemType, amount = dupeItem.amount - canHoldAmount});
                
            }
            else 
            {
                RemoveItem(item);
            }
        } else {
            Debug.Log("fell into the cannot hold");
        }
    }

    public void RecycleAll()
    {

        List<Item> itemList = new List<Item>();
        List<Item> items = GetItemList();

        if (items == null) {return;}

        foreach (Item item in items)
        {
            if(item.CanRecycle() == false)
            {
                continue;
            }
            if(RecyclingInventory.GetRecyclingSkill() < item.RecycleRequirement())
            {
                continue;
            }
            itemList.Add(item);
        }


         //get audio manager
        _audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        
        GameObject recyclerGameObject = GameObject.FindGameObjectWithTag("Recycler");
        RecyclerWorld recWorld = recyclerGameObject.GetComponent<RecyclerWorld>();
        Recycler rec = recWorld.GetRecycler();
        float yield = rec.GetYield();

        foreach (Item item in itemList)
        {
            float mass = item.GetRawMass();
            int recycleAmt = item.amount;
            RecyclingQuest.RawType rawType = item.GetItemRawType();
            bool stackable = item.IsStackable();

             //play sound for item recycled (by type)
            if(rawType == RecyclingQuest.RawType.Paper)
            {
                float totalPaper = RecyclingInventory.GetPaperInventory();
                float newTotal = totalPaper + mass * recycleAmt * yield;
                RecyclingInventory.SetPaperInventory(newTotal);
                 //play sound
                _audio.Play("RecyclePaper");
            }
            else if(rawType == RecyclingQuest.RawType.Glass)
            {
                float totalGlass = RecyclingInventory.GetGlassInventory();
                float newTotal = totalGlass + mass * recycleAmt * yield;
                RecyclingInventory.SetGlassInventory(newTotal);
                //play sound
                _audio.Play("RecycleGlass");
            }
                else if(rawType == RecyclingQuest.RawType.Metal)
            {
                float totalMetal = RecyclingInventory.GetMetalInventory();
                float newTotal = totalMetal + mass * recycleAmt * yield;
                RecyclingInventory.SetMetalInventory(newTotal);
                //play sound
                _audio.Play("RecycleMetal");
            }
                else if(rawType == RecyclingQuest.RawType.Wood)
            {
                float totalWood = RecyclingInventory.GetWoodInventory();
                float newTotal = totalWood + mass * recycleAmt * yield;
                RecyclingInventory.SetWoodInventory(newTotal);
                 //play sound
                _audio.Play("RecycleWood");
            }
                else if(rawType == RecyclingQuest.RawType.Plastic)
            {
                float totalPlastic = RecyclingInventory.GetPlasticInventory();
                float newTotal = totalPlastic + mass * recycleAmt * yield;
                RecyclingInventory.SetPlasticInventory(newTotal);
                //play sound
                 _audio.Play("RecyclePlastic");
            }
                else if(rawType == RecyclingQuest.RawType.Rubber)
            {
                float totalRubber = RecyclingInventory.GetRubberInventory();
                float newTotal = totalRubber + mass * recycleAmt * yield;
                RecyclingInventory.SetRubberInventory(newTotal);
                //play sound
                 _audio.Play("RecycleRubber");
            }
                else if(rawType == RecyclingQuest.RawType.Electronic)
            {
                float totalElectronic = RecyclingInventory.GetElectronicInventory();
                float newTotal = totalElectronic + mass * recycleAmt * yield;
                RecyclingInventory.SetElectronicInventory(newTotal);
                //play sound
                 _audio.Play("RecycleElectronic");
            }
            //now remove item from inventory
             RemoveItem(item);
        }
    }

    private int GetCanHoldAmount(Item item)
    {
        int canHoldAmount = 0;
        for(int i = 1; i<item.amount; i++)
        {
            if(i * item.GetRawMass() <= RecyclingInventory.GetAvailableCapacity())
            {
                //.LogWarning("can recycle " + i + " " + item.itemType);
                canHoldAmount = i;
            }
        }
        return canHoldAmount;
    }
           
    public List<Item> GetItemList()
    {
        return itemList;
    }
}
