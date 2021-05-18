﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RecyclingQuest
{
    public bool IsQuestActivated = false;
    public bool IsQuestComplete = false;
    public int questLevel;
    public Item questItem;
    public QuestGoal questGoal;
    public QuestName questName;
    public int goalAmount;
    public int goalProgress;
    public Recycler questBuilding;
    public bool isBuildQuest = false;

    public enum QuestName 
    {
        CollectItem,
        RecycleItem,
        RecycleType,
        CollectType,
        BuildObject,
    }

    public enum QuestGoal 
    {
        ItemCollected,          //specific item collected (# of items)
        ItemRecycled,           //specific item recycled (# of items)
        TypeRecycled,           //raw product type recycled (# of [glass] items)
        TypeCollected,          //raw product type collected (# of [glass] items)
        ItemAmountCollected,    //specific amount of items mass picked up (25kg)
        TypeAmountCollected,    //specific amount of raw product type [mass] collected (25kg)
        BuildObject,            //build a specific thing  
    }

    public string GetQuestShortDesc()
    {
        switch (questName)
        {
            default:
            case QuestName.CollectItem:     return $"Gather {goalAmount} {questItem.GetName()}";
            case QuestName.RecycleItem:     return $"Recycle {goalAmount} {questItem.GetName()}";
            case QuestName.RecycleType:     return $"Recycle {goalAmount} {questItem.RawType()}";
            case QuestName.CollectType:     return $"Gather {goalAmount} {questItem.RawType()}";
            case QuestName.BuildObject:     return $"Build {questBuilding.recyclerType.ToString()}";
        }
    }

    public string GetQuestLongDesc()
    {
        switch(questName)
        {
             default:                               
            case QuestName.CollectItem:      return $"Search the landscape for {questItem.GetName()} until you have gathered {goalAmount} totals.";
            case QuestName.RecycleItem:      return $"Using a recycler, recycle {goalAmount} {questItem.GetName()}.";
            case QuestName.RecycleType:      return $"Using a recycler, recycle {goalAmount} items made of {questItem.RawType()}.";
            case QuestName.CollectType:      return $"Search the landscape and collect {goalAmount} items made of {questItem.RawType()}.";
            case QuestName.BuildObject:      return $"Collect the required materials and build a {questBuilding.GetName()}.";
        }
    }

     public int GetRocketTechReward()
    {
        switch(questLevel)
        {
            default:
            case 1:      return 25;
            case 2:      return 35;
            case 3:      return 50;
            case 4:      return 75;
            case 5:      return 100;
            case 6:      return 150;
            case 7:      return 225;
            case 8:      return 300;
            case 9:      return 400;
            case 10:     return 500;
           
        }
    }

     public bool HasSkillPointUpgrade()
    {
        switch(questName)
        {
            default:
            case QuestName.BuildObject:      return true;
            case QuestName.CollectItem:      return false;
            case QuestName.RecycleItem:      return false;
            case QuestName.RecycleType:      return false;
            case QuestName.CollectType:      return false;
        }
    }

       public string QuestCompleteMessage()
    {
        switch(questName)
        {
            default:
            case QuestName.CollectItem:      return $"Quest complete. You gathered {goalAmount} {questItem.GetName()}.";
            case QuestName.RecycleItem:      return $"{goalAmount} {questItem.GetName()} recycled. Quest complete.";
            case QuestName.RecycleType:      return $"Quest complete. Recycled {goalAmount} {questItem.RawType()} items.";
            case QuestName.CollectType:      return $"{goalAmount} {questItem.RawType()} items collected. Quest complete.";
            case QuestName.BuildObject:      return $"You have built the {questBuilding.recyclerType.ToString()}. Place it anywhere on the ground.";
        }
    }

    public string GetQuestProgressString(bool build)
    {
        if (build)
        {
            return $"{goalProgress} / {goalAmount} {questBuilding.GetName()}";
        }
        return $"{goalProgress} / {goalAmount} {questItem.GetName()}";
    }

    public RecyclingQuest CompleteQuest(RecyclingQuest quest)
    {
        // remove completed quest from active quest
        List<RecyclingQuest> activeQuests = Quests.GetActiveRecyclingQuests();
        activeQuests.Remove(quest);

        // inactivate quest
        quest.IsQuestActivated = false;

        //add quest to completed quest list
        List<RecyclingQuest> completeQuests = Quests.GetCompleteRecyclingQuests();
        completeQuests.Add(quest);
        
        // generate new quest
        RecyclingQuest newQuest = Quests.GenerateNewRecyclingQuest(quest);
        
        // activate new quest and add it to active quests
        activeQuests.Add(newQuest);
        newQuest.IsQuestActivated = true;

        return newQuest;
    }
}

