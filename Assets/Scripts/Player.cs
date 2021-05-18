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

            bool questProgressed = HandleQuestProgress(currentItem);

            if(questProgressed)
            {
                for (int x = activeRecyclingQuests.Count - 1; x > -1; x--)
                {
                   bool isComplete = activeRecyclingQuests[x].IsQuestComplete(); 

                    if(isComplete)
                    {
                        activeRecyclingQuests[x].CompleteQuest(activeRecyclingQuests[x]);
                    }
                }        
            }
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

    private bool HandleQuestProgress(Item currentItem)
    {
        bool progressed = false;

        Item.ItemType type = currentItem.itemType;

        Debug.Log(type.ToString());
        foreach(RecyclingQuest quest in activeRecyclingQuests)
        {
            if(quest.questItem == null) { continue; }

            //if the quest is tracking number of items collected iterate by 1
            if(quest.questItem.itemType == type && quest.questGoal == RecyclingQuest.QuestGoal.CollectItem)
            {
                quest.goalProgress += currentItem.amount;
                progressed = true;
            }
            //if the quest is tracking the amount of item mass collected iterate by item mass
            if(quest.questItem.itemType == type && quest.questGoal == RecyclingQuest.QuestGoal.CollectItemAmount)
            {
                quest.goalProgress += currentItem.GetRawMass();
                progressed = true;
            }
            //if the quest is tracking the number of items collected of a raw type then iterate by 1
              if(quest.questItem.RawType() == currentItem.RawType() && quest.questGoal == RecyclingQuest.QuestGoal.CollectType)
            {
                quest.goalProgress += currentItem.amount;
                progressed = true;
            }
            //if the quest is tracking the amount of item mass collected iterate by item mass
            if(quest.questItem.RawType() == currentItem.RawType() && quest.questGoal == RecyclingQuest.QuestGoal.CollectTypeAmount)
            {
                quest.goalProgress += currentItem.GetRawMass();
                progressed = true;
            }       
        }
        Debug.Log("Progressed is ====== " + progressed);
        return progressed;
    }
}
