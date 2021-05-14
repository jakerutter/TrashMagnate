using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private InventoryUI inventoryUI;

    void Awake()
    {
        inventory = new Inventory(UseItem);   

        inventoryUI.SetPlayer(this);

        // ItemWorld.SpawnItemWorld(new Vector3(1,1), new Item { itemType = Item.ItemType.LargeBattery});
        // ItemWorld.SpawnItemWorld(new Vector3(-1,1), new Item { itemType = Item.ItemType.Book});
        // ItemWorld.SpawnItemWorld(new Vector3(1,-1), new Item { itemType = Item.ItemType.Can});
    } 

    void Start()
    {
        inventoryUI.SetInventory(inventory); 
    }

     private void OnTriggerEnter(Collider collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            //Touching item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    private void UseItem(Item item)
    {
        // switch(item.itemType)
        // {
        //     case Item.ItemType.PlasticBottle: return;
        // }
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }
}
