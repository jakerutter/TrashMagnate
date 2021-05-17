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
        initialQuests.Add(new RecyclingQuest {questName = RecyclingQuest.QuestName.Collect1});
        initialQuests.Add(new RecyclingQuest {questName = RecyclingQuest.QuestName.Collect2});
        initialQuests.Add(new RecyclingQuest {questName = RecyclingQuest.QuestName.Collect3});
        initialQuests.Add(new RecyclingQuest {questName = RecyclingQuest.QuestName.Collect4});
        initialQuests.Add(new RecyclingQuest {questName = RecyclingQuest.QuestName.BuildRecycler1});

        
        ActiveRecyclingQuests = initialQuests;
    }

    private static void InitialLoadLaunchQuests(List<LaunchQuest> launchQuests)
    {
        //this function will find populate the lits of all launch quests
        //this will need to happen from a binary/json or something
        LaunchQuests = launchQuests;
    }
}
