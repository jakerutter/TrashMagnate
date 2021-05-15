// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class RecyclerInventory
// {
//     public event EventHandler OnItemListChanged;

//     private List<Item> itemList;
//     private Inventory inventory;
//     private Action<Item> useItemAction;

//     public RecyclerInventory(Action<Item> useItemAction)
//     {
//         this.useItemAction = useItemAction;
//         itemList = new List<Item>();

//         AddItem(new Item{itemType = Item.ItemType.PlasticBottle, amount = 1});
//         AddItem(new Item{itemType = Item.ItemType.Computer, amount = 5});
//         AddItem(new Item{itemType = Item.ItemType.GrowlerBottle, amount = 1});
//     }

//     public void AddItem(Item item)
//     {
//         if(item.IsStackable())
//         {
//             bool itemAlreadyInInventory = false;
//             foreach (Item inventoryItem in itemList)
//             {
//                 if (inventoryItem.itemType == item.itemType)
//                 {
//                     inventoryItem.amount += item.amount;
//                     itemAlreadyInInventory = true;
//                 }
//             }
//             if (!itemAlreadyInInventory)
//             {
//                 itemList.Add(item);
//             }
//         } 
//         else 
//         {
//             itemList.Add(item);
//         }
        
//         if(OnItemListChanged != null)
//         {
//             OnItemListChanged.Invoke(this, EventArgs.Empty);
//         }
//     }

//     public void RemoveItem(Item item)
//     {
//         if(item.IsStackable())
//         {
//             Item itemInInventory = null;
//             foreach (Item inventoryItem in itemList)
//             {
//                 if (inventoryItem.itemType == item.itemType)
//                 {
//                     inventoryItem.amount -= item.amount;
//                     itemInInventory = inventoryItem;
//                 }
//             }
//             if (itemInInventory != null && itemInInventory.amount <= 0)
//             {
//                 itemList.Remove(itemInInventory);
//             }
//         } 
//         else 
//         {
//             itemList.Remove(item);
//         }
//         if(OnItemListChanged != null)
//         {
//             OnItemListChanged.Invoke(this, EventArgs.Empty);
//         }
//     }

//     public void UseItem(Item item)
//     {
//         useItemAction(item);
//     }

//     public List<Item> GetRecycleInventoryList()
//     {
//         itemList = inventory.GetItemList();

//         foreach(Item item in itemList)
//         {
//             if(item.CanRecycle() == true)
//             {
//                 itemList.Remove(item);
//             }
//         }

//         return itemList;
//     }
// }
