using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Quests
{
    private static RecyclingQuest[] RecyclingQuests;
    private static RecyclingQuest[] ActiveRecyclingQuests;
    private static RecyclingQuest[] CompleteRecyclingQuests;
    private static LaunchQuest[] LaunchQuests;
    private static LaunchQuest[] ActiveLaunchQuests;
    private static LaunchQuest[] CompleteLaunchQuests;

    public static RecyclingQuest[] GetRecyclingQuests()
    {
        return RecyclingQuests;
    }

    public static RecyclingQuest[] GetActiveRecyclingQuests()
    {
        return ActiveRecyclingQuests;
    }

    public static void SetActiveRecyclingQuests(RecyclingQuest[] quests)
    {
        ActiveRecyclingQuests = quests;
    }

    public static RecyclingQuest[] GetCompleteRecyclingQuests()
    {
        return CompleteRecyclingQuests;
    }

    public static void SetCompleteRecyclingQuests(RecyclingQuest[] quests)
    {
        CompleteRecyclingQuests = quests;
    }

    public static LaunchQuest[] GetLaunchQuests()
    {
        return LaunchQuests;
    }

     public static LaunchQuest[] GetActiveLaunchQuests()
    {
        return ActiveLaunchQuests;
    }

    public static void SetActiveLaunchQuests(LaunchQuest[] quests)
    {
        ActiveLaunchQuests = quests;
    }

    public static LaunchQuest[] GetCompleteLaunchQuests()
    {
        return CompleteLaunchQuests;
    }

    public static void SetCompleteLaunchQuests(LaunchQuest[] quests)
    {
        CompleteLaunchQuests = quests;
    }

    private static void InitialLoadRecyclingQuests(RecyclingQuest[] recyclingQuests)
    {
        //this function will find populate the lits of all recycling quests
        //this will need to happen from a binary/json or something
        RecyclingQuests = recyclingQuests;
    }

    private static void InitialLoadLaunchQuests(LaunchQuest[] launchQuests)
    {
        //this function will find populate the lits of all launch quests
        //this will need to happen from a binary/json or something
        LaunchQuests = launchQuests;
    }
}
