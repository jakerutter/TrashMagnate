﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    private List<RecyclingQuest> activeRecyclingQuests;
    private AudioManager _audio;

    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private QuestLogUI questLogUI;

    void Awake()
    {
        inventory = new Inventory(UseItem);   

        inventoryUI.SetPlayer(this);
    } 

    void Start()
    {
        //Quests.InitialLoadRecyclingQuests();
        activeRecyclingQuests = Quests.GetActiveRecyclingQuests();

        _audio = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
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
                bool questProgressed = HandleQuestProgress(activeRecyclingQuests[i], currentItem);

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
                        RecyclingInventory.AddRocketTechPoints(thisQuest.GetRocketTechReward());
                        //Debug.Log("Quest complete!!" + " RT Points = " + RecyclingInventory.GetRocketTechPoints());
                        RecyclingQuest newQuest = thisQuest.CompleteQuest();
                        
                        questComplete = true;
                    }
                }
            }

            if(questComplete)
            {
                 questLogUI.GetComponent<QuestLogUI>().SetActiveQuestTabs(activeRecyclingQuests);
            }

            //Update inventory (not sure this is best place for this)
            inventoryUI.SetInventory(inventory);
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

    private bool HandleQuestProgress(RecyclingQuest quest, Item currentItem)
    {
        bool progressed = false;

        Item.ItemType type = currentItem.itemType;

        //if the quest is tracking number of items collected iterate by 1
        if(quest.questItem.itemType == type && quest.questGoal == RecyclingQuest.QuestGoal.CollectItem)
        {
            //Debug.Log("Progressed type 1." + " Itemtype is " + type);
            quest.goalProgress += currentItem.amount;
            string progressString = quest.GetQuestProgressString(quest.isBuildQuest);
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
            if(quest.questItem.RawType() == currentItem.RawType() && quest.questGoal == RecyclingQuest.QuestGoal.CollectType)
        {
            //Debug.Log("Progressed type 3." + " Itemtype is " + currentItem.RawType());
            quest.goalProgress += currentItem.amount;
            progressed = true;
        }
        //if the quest is tracking the amount of item mass collected iterate by item mass
        if(quest.questItem.RawType() == currentItem.RawType() && quest.questGoal == RecyclingQuest.QuestGoal.CollectTypeAmount)
        {
            //Debug.Log("Progressed type 4." + " Itemtype is " + currentItem.RawType());
            quest.goalProgress += currentItem.GetRawMass();
            progressed = true;
        }       

        return progressed;
    }
}
