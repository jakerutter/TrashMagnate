using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[Serializable]
public class RecyclingQuest
{
    private bool isQuestComplete;

    public bool IsQuestActivated = false;
    public int questLevel;
    public Item questItem;
    public RawType questRawType;
    public QuestGoal questGoal;
    public QuestName questName;
    public int goalAmount;
    public float goalProgress;
    public Recycler questBuilding;
    public bool isBuildQuest = false;

    public enum QuestName 
    {
        CollectItem,
        RecycleItem,
        RecycleType,
        CollectType,
        CollectItemAmount,     
        CollectTypeAmount,   
        RecycleItemAmount,      
        RecycleTypeAmount,  
        BuildObject,
    }

    public enum RawType
    {
        Plastic,        
        Rubber,
        Paper,
        Electronic,
        Wood,
        Metal,
        Glass,
        None
    }

    public enum QuestGoal 
    {
        CollectItem,            //specific item collected (# of items)
        RecycleItem,            //specific item recycled (# of items)
        RecycleType,            //raw product type recycled (# of [glass] items)
        CollectType,            //raw product type collected (# of [glass] items)
        CollectItemAmount,      //specific amount of items mass picked up (25kg)
        CollectTypeAmount,      //specific amount of raw product type [mass] collected (25kg)
        RecycleItemAmount,      //specific amount of items mass recycled (5kg)
        RecycleTypeAmount,      //specific amount of raw product type [mass] recycled (5kg)
        BuildObject,            //build a specific thing  
    }

       public string GetQuestNeed()
    {
        switch (questGoal)
        {
            default:
            case QuestGoal.CollectItem:                 return "item";
            case QuestGoal.RecycleItem:                 return "item";
            case QuestGoal.RecycleType:                 return "type";
            case QuestGoal.CollectType:                 return "type";
            case QuestGoal.BuildObject:                 return "build";
            case QuestGoal.CollectItemAmount:           return "item";
            case QuestGoal.CollectTypeAmount:           return "type";
            case QuestGoal.RecycleItemAmount:           return "item";
            case QuestGoal.RecycleTypeAmount:           return "type";
        }
    }

    public string GetQuestShortDesc()
    {
        switch (questName)
        {
            default:
            case QuestName.CollectItem:               return $"Gather {goalAmount} {questItem.GetName()}";
            case QuestName.RecycleItem:               return $"Recycle {goalAmount} {questItem.GetName()}";
            case QuestName.RecycleType:               return $"Recycle {goalAmount} {questItem.GetItemRawType()}";
            case QuestName.CollectType:               return $"Gather {goalAmount} {questItem.GetItemRawType()}";
            case QuestName.BuildObject:               return $"Build {questBuilding.recyclerType.ToString()}";
            case QuestName.CollectItemAmount:         return $"Collect {goalAmount}kg {questItem.GetName()}";    
            case QuestName.CollectTypeAmount:         return $"Collect {goalAmount}kg {questRawType} items";   
            case QuestName.RecycleItemAmount:         return $"Recycle {goalAmount}kg {questItem.GetName()}";      
            case QuestName.RecycleTypeAmount:         return $"Recycle {goalAmount}kg {questRawType} items";
        }
    }

    public string GetQuestLongDesc()
    {
        switch(questName)
        {
             default:                               
            case QuestName.CollectItem:               return $"Search the landscape for {questItem.GetName()} until you have gathered {goalAmount} total.";
            case QuestName.RecycleItem:               return $"Using a recycler, recycle {goalAmount} {questItem.GetName()}.";
            case QuestName.RecycleType:               return $"Using a recycler, recycle {goalAmount} items made of {questRawType}.";
            case QuestName.CollectType:               return $"Search the landscape and collect {goalAmount} items made of {questRawType}.";
            case QuestName.BuildObject:               return $"Collect the required materials and build a {questBuilding.GetName()}.";
            case QuestName.CollectItemAmount:         return $"Collect {goalAmount}kg {questItem.GetName()}";    
            case QuestName.CollectTypeAmount:         return $"Collect {goalAmount}kg {questRawType} items";   
            case QuestName.RecycleItemAmount:         return $"Recycle {goalAmount}kg {questItem.GetName()}";      
            case QuestName.RecycleTypeAmount:         return $"Recycle {goalAmount}kg {questRawType} items";
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
            case QuestName.CollectItem:               return $"Quest complete. You gathered {goalAmount} {questItem.GetName()}. " + this.GetRocketTechReward().ToString() + " rocket tech points awarded.";
            case QuestName.RecycleItem:               return $"{goalAmount} {questItem.GetName()} recycled. Quest complete." + this.GetRocketTechReward().ToString() + " rocket tech points awarded.";
            case QuestName.RecycleType:               return $"Quest complete. Recycled {goalAmount} {questItem.GetItemRawType()} items." + this.GetRocketTechReward().ToString() + " rocket tech points awarded.";
            case QuestName.CollectType:               return $"{goalAmount} {questItem.GetItemRawType()} items collected. Quest complete." + this.GetRocketTechReward().ToString() + " rocket tech points awarded.";
            case QuestName.BuildObject:               return $"You have built the {questBuilding.GetName()}." + this.GetRocketTechReward().ToString() + " rocket tech points awarded.";
            case QuestName.CollectItemAmount:         return $"Quest Complete. Collected {goalAmount}kg {questItem.GetName()}";    
            case QuestName.CollectTypeAmount:         return $"Quest Complete. Collected {goalAmount}kg {questRawType} items";   
            case QuestName.RecycleItemAmount:         return $"Quest Complete. Recycled {goalAmount}kg {questItem.GetName()}";      
            case QuestName.RecycleTypeAmount:         return $"Quests Complete. Recycled {goalAmount}kg {questRawType} items";
        }
    }

    public string GetQuestProgressString(bool isBuildQuest)
    {
        if (isBuildQuest)
        {
            return $"{goalProgress} / {goalAmount} {questBuilding.GetName()}";
        }

        return $"{goalProgress} / {goalAmount} {questItem.GetName()}";
    }

    public RecyclingQuest CompleteQuest()
    {
        RecyclingQuest quest = this;

         // give player recycling skill point reward
         if(HasSkillPointUpgrade())
         {
             RecyclingInventory.AddRecyclingSkill(1);
         }

        int rocketTechReward = quest.GetRocketTechReward();

        //give player RTpoints reward
        RecyclingInventory.AddRocketTechPoints(rocketTechReward); 

        //Display current RT point total
        GameObject RocketTechPoints = GameObject.FindGameObjectWithTag("RTPointDisplay");
        RocketTechPoints.GetComponent<TextMeshProUGUI>().SetText(RecyclingInventory.GetRocketTechPoints().ToString());

        //send [success] message saying quest complete
        Messenger messenger = GameObject.FindGameObjectWithTag("Messenger").GetComponent<Messenger>();
        //messenger.SetMessage(Messenger.MessageType.Success, "Quest complete. "+ rocketTechReward.ToString() + " rocket tech points awarded.");
        messenger.SetMessage(Messenger.MessageType.Success, QuestCompleteMessage());
        //add quest to completed quest list
        AddQuestToCompletedQuests(quest);

        // inactivate quest
        quest.IsQuestActivated = false;

         // remove completed quest from active quests
        RemoveQuestFromAcitveQuests(quest);
        
        // generate new quest
        RecyclingQuest newQuest = Quests.GenerateNewRecyclingQuest(quest);

        newQuest.IsQuestActivated = true;

        List<RecyclingQuest> activeQuests = Quests.GetActiveRecyclingQuests();
        activeQuests.Add(newQuest);
        Quests.SetActiveRecyclingQuests(activeQuests);

        return newQuest;
    }

    public bool IsQuestComplete()
    {
        isQuestComplete = goalProgress >= goalAmount;
        //Debug.Log("goalProgress = " + goalProgress + " && goalAmount = " + goalAmount);
        return isQuestComplete;
    }

    private void AddQuestToCompletedQuests(RecyclingQuest quest)
    {
        List<RecyclingQuest> completeQuests = Quests.GetCompleteRecyclingQuests();
        if (completeQuests == null) 
        {
            completeQuests = new List<RecyclingQuest>();
        }

        completeQuests.Add(quest);

        Quests.SetCompleteRecyclingQuests(completeQuests);
    }

    private void RemoveQuestFromAcitveQuests(RecyclingQuest quest)
    {
        List<RecyclingQuest> activeQuests = Quests.GetActiveRecyclingQuests();
        activeQuests.Remove(quest);
        Quests.SetActiveRecyclingQuests(activeQuests);
    }
}

