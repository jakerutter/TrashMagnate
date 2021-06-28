using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    private List<RecyclingQuest> activeRecyclingQuests;
    private BuildingInventory buildingInventory;
    private AudioManager _audio;

    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private QuestLogUI questLogUI;
    [SerializeField] private RecycleAll recycleAll;
    [SerializeField] private BuildUI buildUI;

    void Awake()
    {
        inventory = new Inventory(UseItem);   
        buildingInventory = new BuildingInventory(UseBuilding);
        inventoryUI.SetPlayer(this);
        buildUI.SetPlayer(this);
    } 

    void Start()
    {
        //Quests.InitialLoadRecyclingQuests();
        activeRecyclingQuests = Quests.GetActiveRecyclingQuests();

        _audio = FindObjectOfType<AudioManager>();
        
        buildUI.SetBuildingInventory(buildingInventory);
    }

    private void OnTriggerEnter(Collider collider)
    {   
        //put this here because im seeing null ref of inventory
        if (inventory == null)
        {
            Debug.Log("inventory is null in OnTriggerEnter");
            Inventory newInventory = new Inventory(UseItem);
            inventory = newInventory;
        }

        //Debug.Log("In OnTriggerEnter in Player script");
        bool questComplete = false;
        
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();

        if(itemWorld != null)
        {
            //play sound for picking up item
            _audio.Play("PickUpItem");

            //Touching item
            Item currentItem = itemWorld.GetItem();
            inventory.AddItem(currentItem);

            //TODO add flying around player effect before destroying
            itemWorld.DestroySelf();

            List<int> questsUpdated = new List<int>();

            for(int i = 0; i < activeRecyclingQuests.Count; i++)
            {
                bool questProgressed = false;
                RecyclingQuest.QuestGoal thisGoal = activeRecyclingQuests[i].questGoal;
                
                //This quest could only have progressed if it is one of these  4 types
                if(thisGoal == RecyclingQuest.QuestGoal.CollectItem || thisGoal == RecyclingQuest.QuestGoal.CollectType || thisGoal == RecyclingQuest.QuestGoal.CollectItemAmount || thisGoal == RecyclingQuest.QuestGoal.CollectTypeAmount)
                {
                    questProgressed = HandleCollectionQuestProgress(activeRecyclingQuests[i], currentItem);
                }
                
                if(questProgressed)
                {
                    //Debug.Log("activeQuest number " + i + " was progressed");
                    questsUpdated.Add(i);
                }
            }

            if (questsUpdated.Count > 0)
            {
                for(int z = questsUpdated.Count-1; z>=0; z--)
                {
                    RecyclingQuest thisQuest = activeRecyclingQuests[questsUpdated[z]];

                    //Debug.Log("checking complete status for " + questsUpdated[z]);

                    bool isComplete = thisQuest.IsQuestComplete(); 

                    if(isComplete)
                    {
                        _audio.Play("LevelUp");
                        thisQuest.CompleteQuest();
                        
                        questComplete = true;
                        questLogUI.GetComponent<QuestLogUI>().SetActiveQuestTabs();
                    }
                }
            }

            //Update inventory (not sure this is best place for this)
            inventoryUI.SetInventory(inventory);
            recycleAll.SetRecycleAllInv(inventory);
        } else {
            //Debug.Log("ItemWorld is null in player script");
        }
    }

    private void UseItem(Item item)
    {
        // switch(item.itemType)
        // {
        //     case Item.ItemType.PlasticBottle: return;
        // }
    }

    
    private void UseBuilding(Recycler recycler)
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

    private bool HandleCollectionQuestProgress(RecyclingQuest quest, Item currentItem)
    {
        bool progressed = false;

        Item.ItemType type = currentItem.itemType;

        //if the quest is tracking number of items collected iterate by 1
        if(quest.questItem.itemType == type && quest.questGoal == RecyclingQuest.QuestGoal.CollectItem)
        {
            //Debug.Log("Progressed type 1." + " Itemtype is " + type);
            quest.goalProgress += currentItem.amount;
            string progressString = quest.GetQuestProgressString(quest.questGoal);
            //Debug.Log(progressString);
            progressed = true;
        }
        //if the quest is tracking the amount of item mass collected iterate by item mass
        if(quest.questItem.itemType == type && quest.questGoal == RecyclingQuest.QuestGoal.CollectItemAmount)
        {
            //Debug.Log("Progressed type 2." + " Item is " + type);
            quest.goalProgress += currentItem.GetRawMass();
            progressed = true;
        }
        //if the quest is tracking the number of items collected of a raw type then iterate by 1
        if(quest.questRawType == currentItem.GetItemRawType() && quest.questGoal == RecyclingQuest.QuestGoal.CollectType)
        {
            //Debug.Log("Progressed type 3." + " Itemtype is " + currentItem.RawType());
            quest.goalProgress += currentItem.amount;
            progressed = true;
        }
        //if the quest is tracking the amount of item mass collected iterate by item mass
        if(quest.questRawType == currentItem.GetItemRawType() && quest.questGoal == RecyclingQuest.QuestGoal.CollectTypeAmount)
        {
            //Debug.Log("Progressed type 4." + " Itemtype is " + currentItem.RawType());
            quest.goalProgress += currentItem.GetRawMass();
            progressed = true;
        }       

        return progressed;
    }

    public void CheckBuildQuest(Recycler recycler)
    {
        //get active quests
        for(int i=0; i<5; i++)
        {
            //if not a build quest then continue
            if(activeRecyclingQuests[i].questGoal != RecyclingQuest.QuestGoal.BuildObject)
            {
                continue;
            }

            //if questBuilding equals type built then quest is complete
            if(activeRecyclingQuests[i].questBuilding.recyclerType == recycler.recyclerType)
            {
                _audio.Play("LevelUp");
                RecyclingQuest newQuest = activeRecyclingQuests[i].CompleteQuest();
                questLogUI.GetComponent<QuestLogUI>().SetActiveQuestTabs();
                inventoryUI.RefreshRecycleInventoryItems();
            }
        }
    }

    public List<Item> GetInventory()
    {
        return inventory.GetItemList();
    }

    public void RefreshInventory()
    {
        inventoryUI.SetInventory(inventory);
    }

    public void RefreshBuildingInventory()
    {
        buildUI.SetBuildingInventory(buildingInventory);
    }
}
