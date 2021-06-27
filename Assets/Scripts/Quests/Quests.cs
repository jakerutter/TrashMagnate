using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Quests
{
    private static List<RecyclingQuest> ActiveRecyclingQuests;
    private static List<RecyclingQuest> CompleteRecyclingQuests;

    public static List<RecyclingQuest> GetActiveRecyclingQuests()
    {
        return ActiveRecyclingQuests;
    }

    public static void SetActiveRecyclingQuests(List<RecyclingQuest> quests)
    {
        ActiveRecyclingQuests = quests;
    }

    public static List<RecyclingQuest> GetCompleteRecyclingQuests()
    {
        return CompleteRecyclingQuests;
    }

    public static void SetCompleteRecyclingQuests(List<RecyclingQuest> quests)
    {
        CompleteRecyclingQuests = quests;
    }

    public static void InitialLoadRecyclingQuests()
    {
        //TODO this only works for a brand new game, otherwise will need to load saved quest data
        List<RecyclingQuest> initialQuests = new List<RecyclingQuest>();
        
        initialQuests.Add(new RecyclingQuest 
        {
            questName = RecyclingQuest.QuestName.CollectItem, 
            questLevel = 1,
            questGoal = RecyclingQuest.QuestGoal.CollectItem,
            goalAmount = 10,
            questItem = new Item {itemType = Item.ItemType.Can}
        });

        initialQuests.Add(new RecyclingQuest 
        {
            questName = RecyclingQuest.QuestName.CollectItem, 
            questLevel = 1,
            questGoal = RecyclingQuest.QuestGoal.CollectItem,
            goalAmount = 10,
            questItem = new Item {itemType = Item.ItemType.BrownGlassBottle}
        });

        initialQuests.Add(new RecyclingQuest 
        {
            questName = RecyclingQuest.QuestName.CollectItem, 
            questLevel = 1,
            questGoal = RecyclingQuest.QuestGoal.CollectItem,
            goalAmount = 10,
            questItem = new Item {itemType = Item.ItemType.SmallTire}
        });

        initialQuests.Add(new RecyclingQuest 
        {
            questName = RecyclingQuest.QuestName.CollectItem, 
            questLevel = 1,
            questGoal = RecyclingQuest.QuestGoal.CollectItem,
            goalAmount = 10,
            questItem = new Item {itemType = Item.ItemType.Box}
        });
        
        initialQuests.Add(new RecyclingQuest 
        {
            questName = RecyclingQuest.QuestName.BuildObject,
            questGoal = RecyclingQuest.QuestGoal.BuildObject,
            questLevel = 1,
            goalAmount = 1,
            isBuildQuest = true,
            questItem = new Item { itemType = Item.ItemType.None },
            questBuilding = new Recycler {recyclerType = Recycler.RecyclerType.BasicRecycler}
        });

        ActiveRecyclingQuests = initialQuests;
    }

    public static RecyclingQuest GenerateNewRecyclingQuest(RecyclingQuest quest)
    {
        //iterate level by 1 until max level is reached
        int newLevel = GetNewQuestLevel(quest.questLevel);

        int randInt = Random.Range(0,9);
        int randomRawType = Random.Range(0, 8);
        int randItem = Random.Range(0, 21);

        //create newQuest -- then fill in the missing pieces
         RecyclingQuest newQuest = new RecyclingQuest {
            questLevel = newLevel,
            questName = (RecyclingQuest.QuestName)randInt,
            questGoal = (RecyclingQuest.QuestGoal)randInt
        };

        Debug.LogWarning("Quest Need is " + newQuest.GetQuestNeed());

        //if questGoal needs item generate random item
        Item newItem;
        string questNeed = newQuest.GetQuestNeed();
        if (questNeed == "item")
        {
           newItem = new Item { itemType = (Item.ItemType)randItem };
        } 
        else 
        {
            newItem = new Item { itemType = Item.ItemType.None };
        }

        //if questGoal needs type generate random type
        RecyclingQuest.RawType newRawType;
        if(questNeed == "type")
        {
            newRawType = (RecyclingQuest.RawType)randomRawType;
        }
        else 
        {
            newRawType =  RecyclingQuest.RawType.None;
        }
        
        newQuest.questItem = newItem;
        newQuest.questRawType = newRawType;
        newQuest.goalAmount = GetAmountByLevel(newLevel);
        
        // get active quests and add this new quest to the list
        List<RecyclingQuest> activeQuests = GetActiveRecyclingQuests();

        activeQuests.Remove(quest);

        activeQuests.Add(newQuest);

        Quests.SetActiveRecyclingQuests(activeQuests);

        return newQuest;
    }

    private static int GetNewQuestLevel(int level)
    {
        if(level < 10)
        {
            return level + 1;
        } else 
        {
            return level;
        }
    }

    private static int GetAmountByLevel(int level)
    {
        //TODO this should return a different amound for # items
        //than amount [kgs] to collect /recycle etc
        return level * 10;
    }
}
