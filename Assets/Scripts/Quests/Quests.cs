using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Quests
{
    private static List<RecyclingQuest> RecyclingQuests;
    private static List<RecyclingQuest> ActiveRecyclingQuests;
    private static List<RecyclingQuest> CompleteRecyclingQuests;
    private static List<LaunchQuest> LaunchQuests;
    private static List<LaunchQuest> ActiveLaunchQuests;
    private static List<LaunchQuest> CompleteLaunchQuests;

    public static List<RecyclingQuest> GetRecyclingQuests()
    {
        return RecyclingQuests;
    }

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
            questGoal = RecyclingQuest.QuestGoal.ItemCollected,
            goalAmount = 15,
            questItem = new Item {itemType = Item.ItemType.Can}
        });

        initialQuests.Add(new RecyclingQuest 
        {
            questName = RecyclingQuest.QuestName.CollectType, 
            questLevel = 1,
            questGoal = RecyclingQuest.QuestGoal.ItemCollected,
            goalAmount = 15,
            questItem = new Item {itemType = Item.ItemType.BrownGlassBottle}
        });

        initialQuests.Add(new RecyclingQuest 
        {
            questName = RecyclingQuest.QuestName.CollectItem, 
            questLevel = 1,
            questGoal = RecyclingQuest.QuestGoal.ItemCollected,
            goalAmount = 5,
            questItem = new Item {itemType = Item.ItemType.SmallTire}
        });

        initialQuests.Add(new RecyclingQuest 
        {
            questName = RecyclingQuest.QuestName.CollectItem, 
            questLevel = 1,
            questGoal = RecyclingQuest.QuestGoal.ItemCollected,
            goalAmount = 5,
            questItem = new Item {itemType = Item.ItemType.Box}
        });
        
        initialQuests.Add(new RecyclingQuest 
        {
            questName = RecyclingQuest.QuestName.BuildObject, 
            questLevel = 1,
            goalAmount = 1,
            isBuildQuest = true,
            questBuilding = new Recycler {recyclerType = Recycler.RecyclerType.BasicRecycler}

        });

        ActiveRecyclingQuests = initialQuests;
    }

    private static void InitialLoadLaunchQuests(List<LaunchQuest> launchQuests)
    {
        //this function will find populate the lits of all launch quests
        //this will need to happen from a binary/json or something
        LaunchQuests = launchQuests;
    }

    public static void UpdateActiveQuestProgress()
    {

    }

    public static RecyclingQuest GenerateNewRecyclingQuest(RecyclingQuest quest)
    {
        //itemList.Add(new Item { itemType = Item.ItemType.Can, amount = 4});
        //iterate level by 1 until max level is reached
        int newLevel = GetNewQuestLevel(quest.questLevel);

        //cardSuit = (CardSuit)Random.Range(0, 3);

        RecyclingQuest newQuest = new RecyclingQuest {
            questLevel = newLevel,
            questName = (RecyclingQuest.QuestName)Random.Range(0,5)

        };

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

    
}
