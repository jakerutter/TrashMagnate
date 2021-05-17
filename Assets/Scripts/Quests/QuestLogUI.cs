using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using CodeMonkey.Utils;

public class QuestLogUI : MonoBehaviour
{
    public List<GameObject> activeQuestTabs;
    public List<GameObject> questTexts;
    public List<GameObject> questRewards;
    public GameObject selectedQuestDetail;
    public GameObject selectedQuestProgress;

    private List<RecyclingQuest> activeQuests;


    private void Start()
    {
        //load the start game qusts
        //TODO --only do this for new games, not loaded save games
        Quests.InitialLoadRecyclingQuests();

        activeQuests = Quests.GetActiveRecyclingQuests();
        SetActiveQuests(activeQuests);

        for(int i = 0; i < activeQuestTabs.Count; i++)
        {
            activeQuestTabs[i].GetComponent<Button_UI>().ClickFunc = () => {
                SetSelectedQuest(activeQuests[i]);
            };
        }
    }

    public void SetSelectedQuest(RecyclingQuest quest)
    {
        
    }

    public void SetActiveQuests(List<RecyclingQuest> activeQuests)
    {
        for(int i = 0; i<5; i++)
        {
            RecyclingQuest thisQuest = activeQuests[i];
            
            TextMeshProUGUI questShortDesc = questTexts[i].GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI questReward = questRewards[i].GetComponent<TextMeshProUGUI>();

            questShortDesc.SetText(thisQuest.GetQuestShortDesc());
            int rocketTechPoints = thisQuest.GetRocketTechReward();
            string text = "Reward: " + rocketTechPoints + " rocket tech ponts";

            if(thisQuest.HasSkillPointUpgrade() == true)
            {
                text += " \n +1 recycling skill";
            }
        }
    }
}
