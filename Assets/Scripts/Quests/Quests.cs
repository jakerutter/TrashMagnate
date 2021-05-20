using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Quests
{
    // private static List<RecyclingQuest> RecyclingQuests;
    private static List<RecyclingQuest> ActiveRecyclingQuests;
    private static List<RecyclingQuest> CompleteRecyclingQuests;
    private static List<LaunchQuest> LaunchQuests;
    private static List<LaunchQuest> ActiveLaunchQuests;
    private static List<LaunchQuest> CompleteLaunchQuests;

    // public static List<RecyclingQuest> GetRecyclingQuests()
    // {
    //     return RecyclingQuests;
    // }

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

    public static List<LaunchQuest> GetLaunchQuests()
    {
        return LaunchQuests;
    }

     public static List<LaunchQuest> GetActiveLaunchQuests()
    {
        return ActiveLaunchQuests;
    }

    public static void SetActiveLaunchQuests(List<LaunchQuest> quests)
    {
        ActiveLaunchQuests = quests;
    }

    public static List<LaunchQuest> GetCompleteLaunchQuests()
    {
        return CompleteLaunchQuests;
    }

    public static void SetCompleteLaunchQuests(List<LaunchQuest> quests)
    {
        CompleteLaunchQuests = quests;
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
            goalAmount = 15,
            questItem = new Item {itemType = Item.ItemType.Can}
        });

        initialQuests.Add(new RecyclingQuest 
        {
            questName = RecyclingQuest.QuestName.CollectItem, 
            questLevel = 1,
            questGoal = RecyclingQuest.QuestGoal.CollectItem,
            goalAmount = 15,
            questItem = new Item {itemType = Item.ItemType.BrownGlassBottle}
        });

        initialQuests.Add(new RecyclingQuest 
        {
            questName = RecyclingQuest.QuestName.CollectItem, 
            questLevel = 1,
            questGoal = RecyclingQuest.QuestGoal.CollectItem,
            goalAmount = 5,
            questItem = new Item {itemType = Item.ItemType.SmallTire}
        });

        initialQuests.Add(new RecyclingQuest 
        {
            questName = RecyclingQuest.QuestName.CollectItem, 
            questLevel = 1,
            questGoal = RecyclingQuest.QuestGoal.CollectItem,
            goalAmount = 5,
            questItem = new Item {itemType = Item.ItemType.Box}
        });
        
        initialQuests.Add(new RecyclingQuest 
        {
            //questName = RecyclingQuest.QuestName.BuildObject, 
            questName = RecyclingQuest.QuestName.CollectItem,
            questLevel = 1,
            goalAmount = 1,
            //isBuildQuest = true,
            //questItem = null,
            questItem = new Item {itemType = Item.ItemType.GroceryBag},
            //questBuilding = new Recycler {recyclerType = Recycler.RecyclerType.BasicRecycler}
        });

        ActiveRecyclingQuests = initialQuests;
    }

    private static void InitialLoadLaunchQuests(List<LaunchQuest> launchQuests)
    {
        LaunchQuests = launchQuests;
    }

    public static RecyclingQuest GenerateNewRecyclingQuest(RecyclingQuest quest)
    {
        //iterate level by 1 until max level is reached
        int newLevel = GetNewQuestLevel(quest.questLevel);

        //cardSuit = (CardSuit)Random.Range(0, 3);
        int randInt = Random.Range(0,5);
        int randItem = Random.Range(0, 22);
        RecyclingQuest newQuest = new RecyclingQuest {
            questLevel = newLevel,
            questName = (RecyclingQuest.QuestName)randInt,
            questGoal = (RecyclingQuest.QuestGoal)randInt,
            questItem = new Item{ itemType = (Item.ItemType)randItem },
            goalAmount = GetAmountByLevel(newLevel)
        };
        
        // get active quests and add this new quest to the list
        List<RecyclingQuest> activeQuests = GetActiveRecyclingQuests();

        Debug.LogWarning("active quest count before adding new = " + activeQuests.Count);

        activeQuests.Add(newQuest);

        Debug.LogWarning("active quest count after adding new = " + activeQuests.Count);

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
        return level * 10;
    }
}
