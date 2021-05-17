using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RecyclingQuest
{
    public bool IsQuestActivated = false;
    public bool IsQuestComplete = false;
    public int questLevel;

    public enum QuestName 
    {
        BuildRecycler1,
        BuildRecycler2,
        BuildRecycler3,
        Collect1,
        Collect2,
        Collect3,
        Collect4,
        Recycle1,
        Recycle2,
        Recycle3, 
    }

    public QuestName questName;

    public enum QuestGoal 
    {
        ItemCollected,          //specific item collected (# of items)
        ItemRecycled,           //specific item recycled (# of items)
        TypeRecycled,           //raw product type recycled (# of items)
        TypeCollected,          //raw product type collected (# of items)
        BuildObject,            //build a specific thing
        LaunchHeight,           //reach a specific altitude during flight
        LaunchDuration,         //launch a rocket for specific duration
        LaunchMass,             //launch a rocket of a specific mass
        LaunchComplexity,       //launch a rocket (# of parts)   
    }

    public QuestGoal goal;

    public string GetQuestShortDesc()
    {
        switch (questName)
        {
            default:
            case QuestName.Collect1:            return "Gather 15 cans";
            case QuestName.Collect2:            return "Gather 5 glass bottles";
            case QuestName.Collect3:            return "Gather 5 small tires";
            case QuestName.Collect4:            return "Gather 5 cardboard boxes";
            case QuestName.BuildRecycler1:      return "Build basic recycler";
            case QuestName.BuildRecycler2:      return "Build modern recycler";
            case QuestName.BuildRecycler3:      return "Build advanced recycler";
            case QuestName.Recycle1:            return "Recycle 5kg metal products";
            case QuestName.Recycle2:            return "Recycle 5kg wood products";
            case QuestName.Recycle3:            return "Recycle 10kg rubber products";
        }
    }

    public string GetQuestLongDesc()
    {
        switch(questName)
        {
             default:                               
            case QuestName.Collect1:            return "Search the landscape for aluminum cans until you have gathered 15 total";
            case QuestName.Collect2:            return "Search the landscape for glass bottles until you have gathered 15 total";
            case QuestName.Collect3:            return "Search the landscape for small tires until you have gathered 5 total";
            case QuestName.Collect4:            return "Search the landscape for cardboard boxes until you have gathered 5 total";
            case QuestName.BuildRecycler1:      return "To build the basic recycler you need: 15 cans, 15 bottles, 5 small tires, 5 cardboard boxes.";
            case QuestName.BuildRecycler2:      return "To build the modern recycler you need: TODO";
            case QuestName.BuildRecycler3:      return "To build the advanced recycler you need: TODO";
            case QuestName.Recycle1:            return "Make use of a recycler to receive 5kg metal products";
            case QuestName.Recycle2:            return "Make use of a recycler to receive 5kg wood products";
            case QuestName.Recycle3:            return "Make use of a recycler to receive 10kg rubber products";
        }
    }

    //  public int GetRocketTechReward()
    // {
    //     switch(questName)
    //     {
    //         default:
    //         case QuestName.BuildRecycler1:      return 100;
    //         case QuestName.BuildRecycler2:      return 200;
    //         case QuestName.BuildRecycler3:      return 300;
    //         case QuestName.Collect1:            return 25;
    //         case QuestName.Collect2:            return 25;
    //         case QuestName.Collect3:            return 25;
    //         case QuestName.Collect4:            return 25;
    //         case QuestName.Recycle1:            return 50;
    //         case QuestName.Recycle2:            return 50;
    //         case QuestName.Recycle3:            return 50;
    //     }
    // }

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
            case QuestName.BuildRecycler1:      return true;
            case QuestName.BuildRecycler2:      return true;
            case QuestName.BuildRecycler3:      return true;
            case QuestName.Collect1:            return false;
            case QuestName.Collect2:            return false;
            case QuestName.Collect3:            return false;
            case QuestName.Collect4:            return false;
            case QuestName.Recycle1:            return false;
            case QuestName.Recycle2:            return false;
            case QuestName.Recycle3:            return false;
        }
    }

       public string QuestCompleteMessage()
    {
        switch(questName)
        {
            default:
            case QuestName.Collect1:            return "15 cans found. Quest complete.";
            case QuestName.Collect2:            return "15 glass bottles found. Quest complete.";
            case QuestName.Collect3:            return "5 small tires found. Quest complete.";
            case QuestName.Collect4:            return "5 cardboard boxes found. Quest complete.";
            case QuestName.BuildRecycler1:      return "You have built the basic recycler. Place it anywhere on the ground. You can now recycle items!";
            case QuestName.BuildRecycler2:      return "You have built the modern recycler. Your recycling yield has improved.";
            case QuestName.BuildRecycler3:      return "You have built the basic recycler. Your recycling yield has greatly improved.";
            case QuestName.Recycle1:            return "Quest complete. You recycled 5kg metal products";
            case QuestName.Recycle2:            return "Quest complete. You recycled 5kg wood products";
            case QuestName.Recycle3:            return "Quest complete. You recycled 10kg rubber products";
        }
    }

    public string GetQuestProgressString()
    {
        return "";
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

