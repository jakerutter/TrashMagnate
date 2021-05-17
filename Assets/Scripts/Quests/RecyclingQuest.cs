using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RecyclingQuest
{
    public enum QuestName {
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

    public string GetQuestShortDesc()
    {
        switch (questName)
        {
            default:
            case QuestName.Collect1:            return "Gather 15 cans";
            case QuestName.Collect2:            return "Gather 15 glass bottles";
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
            case QuestName.Collect1:            return "Search the landscape for aluminum cans. You can track progress in the quest log.";
            case QuestName.Collect2:            return "Search the landscape for glass bottles. You can track progress in the quest log.";
            case QuestName.Collect3:            return "Search the landscape for small tires. You can track progress in the quest log.";
            case QuestName.Collect4:            return "Search the landscape for cardboard boxes. You can track progress in the quest log.";
            case QuestName.BuildRecycler1:      return "To build the basic recycler you need: 15 cans, 15 bottles, 5 small tires, 5 cardboard boxes.";
            case QuestName.BuildRecycler2:      return "To build the modern recycler you need: TODO";
            case QuestName.BuildRecycler3:      return "To build the advanced recycler you need: TODO";
            case QuestName.Recycle1:            return "Make use of a recycler to receive 5kg metal products";
            case QuestName.Recycle2:            return "Make use of a recycler to receive 5kg wood products";
            case QuestName.Recycle3:            return "Make use of a recycler to receive 10kg rubber products";
        }
    }

     public int GetRocketTechReward()
    {
        switch(questName)
        {
            default:
            case QuestName.BuildRecycler1:      return 100;
            case QuestName.BuildRecycler2:      return 200;
            case QuestName.BuildRecycler3:      return 300;
            case QuestName.Collect1:            return 25;
            case QuestName.Collect2:            return 25;
            case QuestName.Collect3:            return 25;
            case QuestName.Collect4:            return 25;
            case QuestName.Recycle1:            return 50;
            case QuestName.Recycle2:            return 50;
            case QuestName.Recycle3:            return 50;
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

     public string QuestUnlockName()
    {
        switch(questName)
        {
             default:
            case QuestName.Collect1:            return "CollectCan2";
            case QuestName.Collect2:            return "CollectPlasticJug2";
            case QuestName.Collect3:            return "CollectWood2";
            case QuestName.Collect4:            return "CollectElectronic1";
            case QuestName.BuildRecycler1:      return "TODO";
            case QuestName.BuildRecycler2:      return "TODO";
            case QuestName.BuildRecycler3:      return "TODO";
            case QuestName.Recycle1:            return "TODO";
            case QuestName.Recycle2:            return "TODO";
            case QuestName.Recycle3:            return "TODO";
        }
    }

    public bool IsQuestActivated()
    {
        switch (questName)
        {
            default:
            case QuestName.Collect1:            return false;
            case QuestName.Collect2:            return false;
            case QuestName.Collect3:            return false;
            case QuestName.Collect4:            return false;
            case QuestName.BuildRecycler1:      return false;
            case QuestName.BuildRecycler2:      return false;
            case QuestName.BuildRecycler3:      return false;
            case QuestName.Recycle1:            return false;
            case QuestName.Recycle2:            return false;
            case QuestName.Recycle3:            return false;
        }
    }

     public bool IsQuestComplete()
    {
        switch (questName)
        {
            default:
            case QuestName.Collect1:            return false;
            case QuestName.Collect2:            return false;
            case QuestName.Collect3:            return false;
            case QuestName.Collect4:            return false;
            case QuestName.BuildRecycler1:      return false;
            case QuestName.BuildRecycler2:      return false;
            case QuestName.BuildRecycler3:      return false;
            case QuestName.Recycle1:            return false;
            case QuestName.Recycle2:            return false;
            case QuestName.Recycle3:            return false;
        }
    }
}

