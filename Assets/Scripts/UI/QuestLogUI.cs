using System.Collections.Generic;
using UnityEngine;
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

    private void Awake()
    {
        //load the start game qusts
        //TODO --only do this for new games, not loaded save games
        Quests.InitialLoadRecyclingQuests();
    }
    
    private void Start()
    {
        SetActiveQuestTabs();
    }

    public void SetActiveQuestTabs()
    {
        List<RecyclingQuest> activeQuests = Quests.GetActiveRecyclingQuests();

        for(int i = 0; i<5; i++)
        {
            RecyclingQuest thisQuest = activeQuests[i];

            GameObject questTemplate = activeQuestTabs[i];
            TextMeshProUGUI questShortDesc = questTexts[i].GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI questReward = questRewards[i].GetComponent<TextMeshProUGUI>();

            questShortDesc.SetText(thisQuest.GetQuestShortDesc());
            int rocketTechPoints = thisQuest.GetRecyclingTechReward();
            string text = "Reward: " + rocketTechPoints + " rocket tech points";

            if(thisQuest.HasSkillPointUpgrade() == true)
            {
                text += " & +1 recycling skill";
            }

            questReward.SetText(text);

            questTemplate.GetComponent<Button_UI>().ClickFunc = () => {
                SetSelectedQuest(thisQuest);
            };
        }
    }

    public void SetSelectedQuest(RecyclingQuest quest)
    {
        Debug.Log("Setting Selected quest");
        selectedQuestDetail.GetComponent<TextMeshProUGUI>().SetText(quest.GetQuestLongDesc());
        selectedQuestProgress.GetComponent<TextMeshProUGUI>().SetText(quest.GetQuestProgressString(quest.questGoal));
    }
}
