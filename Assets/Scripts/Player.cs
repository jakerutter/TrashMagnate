using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    private List<RecyclingQuest> activeRecyclingQuests;
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
        activeRecyclingQuests = Quests.GetActiveRecyclingQuests();
        inventoryUI.SetInventory(inventory); 
    }

    private void OnTriggerEnter(Collider collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            //Touching item
            Item currentItem = itemWorld.GetItem();
            inventory.AddItem(currentItem);
            
            //TODO add flying around player effect before destroying
            //TODO add sound for picking up item
            itemWorld.DestroySelf();

            HandleQuestProgress(currentItem);
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

    private void HandleQuestProgress(Item currentItem)
    {
        Item.ItemType type = currentItem.itemType;

        foreach(RecyclingQuest quest in activeRecyclingQuests)
        {
            if(true)
            {
                Debug.Log("truth");
            }
        }
    }
}
