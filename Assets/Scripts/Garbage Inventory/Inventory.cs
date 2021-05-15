using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;
    private Action<Item> useItemAction;

    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();

        itemList.Add(new Item { itemType = Item.ItemType.Can, amount = 4});
    }

    public void AddItem(Item item)
    {
        if(item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            Debug.LogWarning("itemList count is " + itemList.Count + " in AddItem");
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                //getting here!
                Debug.LogWarning("whoop");
                itemList.Add(item);
                Debug.LogWarning("!!! " +itemList.Count + " is the count");
            }
        } 
        else 
        {
            Debug.LogWarning("wwoop2");
            itemList.Add(item);
        }
        if(OnItemListChanged != null)
        {
            //getting here too
            Debug.LogWarning("swonk swonk");
            OnItemListChanged.Invoke(this, EventArgs.Empty);
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
        int requirement = item.RecycleRequirement();
        float mass = item.GetRawMass();
        string rawType = item.RawType();
        bool stackable = item.IsStackable();
        int canHoldAmount = 0;
        bool canHoldAll = true;

        GameObject recyclerGameObject = GameObject.FindGameObjectWithTag("Recycler");
        Recycler rec = recyclerGameObject.GetComponent<Recycler>();
        float yield = rec.GetYield();
        Debug.Log("*** " + yield + " ***");
        //check item Recycle skill level
        if(requirement > RecyclingInventory.GetRecyclingSkill())
        {
            Debug.LogWarning("Insufficient skill for recycling this item");
            return;
        }

        // check available inventory  space against mass
        bool canHold = RecyclingInventory.HaveAvailableCapacity(mass * item.amount * yield);
        canHoldAll = canHold;
        //cant hold the entire stack of items
        if(!canHold && item.amount > 1)
        {
            if(RecyclingInventory.HaveAvailableCapacity(mass * yield))
            {
                canHoldAmount = GetCanHoldAmount(item);
                canHold = true;
            }
        }

        //if there is enough room, add it
        if(canHold)
        {
            int recycleAmt = item.amount;

            Debug.Log("Item to recycle: " + canHoldAmount + " " + item.itemType + "\n Item mass: " + mass + "\n Item raw type: " + rawType + "\n Yield: " + yield);
            
            if(canHoldAmount > 0)
            {
                recycleAmt = canHoldAmount;
            }

            //play sound for item recycled (by type)
            if(rawType == "Paper")
            {
                float totalPaper = RecyclingInventory.GetPaperInventory();
                float newTotal = totalPaper + mass * recycleAmt * yield;
                RecyclingInventory.SetPaperInventory(newTotal);
            }
            else if(rawType == "Glass")
            {
                float totalGlass = RecyclingInventory.GetGlassInventory();
                float newTotal = totalGlass + mass * recycleAmt * yield;
                RecyclingInventory.SetGlassInventory(newTotal);
            }
                else if(rawType == "Metal")
            {
                float totalMetal = RecyclingInventory.GetMetalInventory();
                float newTotal = totalMetal + mass * recycleAmt * yield;
                RecyclingInventory.SetMetalInventory(newTotal);
            }
                else if(rawType == "Wood")
            {
                float totalWood = RecyclingInventory.GetWoodInventory();
                float newTotal = totalWood + mass * recycleAmt * yield;
                RecyclingInventory.SetWoodInventory(newTotal);
            }
                else if(rawType == "Plastic")
            {
                float totalPlastic = RecyclingInventory.GetPlasticInventory();
                float newTotal = totalPlastic + mass * recycleAmt * yield;
                RecyclingInventory.SetPlasticInventory(newTotal);
            }
                else if(rawType == "Rubber")
            {
                float totalRubber = RecyclingInventory.GetRubberInventory();
                float newTotal = totalRubber + mass * recycleAmt * yield;
                RecyclingInventory.SetRubberInventory(newTotal);
            }
                else if(rawType == "Electronic")
            {
                float totalElectronic = RecyclingInventory.GetElectronicInventory();
                float newTotal = totalElectronic + mass * recycleAmt * yield;
                RecyclingInventory.SetElectronicInventory(newTotal);
            }
            
            RecyclingInventory.AdjustAvailableCapacity(mass);

            //if entire item was not recycled, remove item and replace with less items
            if(!canHoldAll)
            {
                Debug.Log("recycling "+ canHoldAmount + " " + item.itemType);
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

    public void RecycleAll(Item[] items)
    {
        //TODO not sure which order we want to iterated through if we do
        //get all items in inventory
        //iterate through each item

        //remove item if either item cannot be recycled
        //remove item if skill level is inadequate

        //if can hold current item (or stack) add all

        //if cannot hold all of current item (or stack) then fit what can be held

        //iterate all items in case items with less mass come later and may fit
        
    }

    private int GetCanHoldAmount(Item item)
    {
        int canHoldAmount = 0;
        for(int i = 1; i<item.amount; i++)
        {
            if(i * item.GetRawMass() <= RecyclingInventory.GetAvailableCapacity())
            {
                Debug.LogWarning("can recycle " + i + " " + item.itemType);
                canHoldAmount = i;
            }
        }
        return canHoldAmount;
    }
           
    public List<Item> GetItemList()
    {
        Debug.Log("itemList has " + itemList.Count + " items in GetItemList");
        return itemList;
    }
}
