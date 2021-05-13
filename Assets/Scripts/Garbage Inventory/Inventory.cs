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
    }

    public void AddItem(Item item)
    {
        if(item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
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
                itemList.Add(item);
            }
        } 
        else 
        {
            itemList.Add(item);
        }
        
        if(OnItemListChanged != null)
        {
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
        //check item Recycle skill level
        if(requirement > RecyclingInventory.GetRecyclingSkill())
        {
            Debug.LogWarning("Insufficient skill for recycling this item");
            return;
        }

        // check available inventory  space against mass
        bool canHold = RecyclingInventory.HaveAvailableCapacity(mass * item.amount);

        //cant hold the entire stack of items
        if(!canHold && item.amount > 1)
        {
            if(RecyclingInventory.HaveAvailableCapacity(item.GetRawMass()))
            {
                canHoldAmount = GetCanHoldAmount(item);
                canHold = true;
            }
        }

        //if there is enough room, add it
        if(canHold)
        {
            int recycleAmt = item.amount;

            Debug.Log("Item to recycle: " + canHoldAmount + " " + item.itemType + "\n Item mass: " + mass + "\n Item raw type: " + rawType);
            
            if(canHoldAmount > 0)
            {
                recycleAmt = canHoldAmount;
            }

            //play sound for item recycled (by type)
            if(rawType == "Paper")
            {
                float totalPaper = RecyclingInventory.GetPaperInventory();
                float newTotal = totalPaper + mass * recycleAmt;
                RecyclingInventory.SetPaperInventory(newTotal);
            }
            else if(rawType == "Glass")
            {
                float totalGlass = RecyclingInventory.GetGlassInventory();
                float newTotal = totalGlass + mass * recycleAmt;
                RecyclingInventory.SetGlassInventory(newTotal);
            }
                else if(rawType == "Metal")
            {
                float totalMetal = RecyclingInventory.GetMetalInventory();
                float newTotal = totalMetal + mass * recycleAmt;
                RecyclingInventory.SetMetalInventory(newTotal);
            }
                else if(rawType == "Wood")
            {
                float totalWood = RecyclingInventory.GetWoodInventory();
                float newTotal = totalWood + mass * recycleAmt;
                RecyclingInventory.SetWoodInventory(newTotal);
            }
                else if(rawType == "Plastic")
            {
                float totalPlastic = RecyclingInventory.GetPlasticInventory();
                float newTotal = totalPlastic + mass * recycleAmt;
                RecyclingInventory.SetPlasticInventory(newTotal);
            }
                else if(rawType == "Rubber")
            {
                float totalRubber = RecyclingInventory.GetRubberInventory();
                float newTotal = totalRubber + mass * recycleAmt;
                RecyclingInventory.SetRubberInventory(newTotal);
            }
                else if(rawType == "Electronic")
            {
                float totalElectronic = RecyclingInventory.GetElectronicInventory();
                float newTotal = totalElectronic + mass * recycleAmt;
                RecyclingInventory.SetElectronicInventory(newTotal);
            }
            
            RecyclingInventory.AdjustAvailableCapacity(mass);

            //if entire item was not recycled, remove item and replace with less items
            if(canHoldAmount < item.amount && item.amount > 1)
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
        }
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
        return itemList;
    }
}
