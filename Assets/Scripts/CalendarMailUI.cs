using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class CalendarMailUI : MonoBehaviour
{
    private static int CurrentDay = 5;
    private static int CurrentYear = 1;
    private static List<int> DecisionDay = new List<int>() { 7, 13 };

    public GameObject CalendarIcon;
    public GameObject MailIcon;
    public List<GameObject> CalendarDays;
    public GameObject CalendarDate;
    public TMP_FontAsset FontAssetWhite;
    public TMP_FontAsset FontAssetBlue;
    public List<Tab> Tabs;
    public List<GameObject> UIPanels;
    public GameObject MainPanel;

    void Start()
    {
        UpdateCalendarColors();

        //set the button click functions for toggling the calendar/mail ui and setting the active tab/panel
        foreach (Tab tab in Tabs)
        {
            tab.GetComponent<Button_UI>().ClickFunc = () => {
                SetPanel(tab);
            };
        }
    }

    public static int GetCurrentDay()
    {
        return CurrentDay;
    }

    public void UpdateCurrentDay()
    {
        CurrentDay += 1;
        UpdateCalendarColors();
    }

    public int GetCurrentYear()
    {
        return CurrentYear;
    }

    public void UpdateCurrentYear()
    {
        CurrentYear += 1;
    }

    public void UpdateCalendarColors()
    {
        //set day and year
        TextMeshProUGUI textUI = CalendarDate.GetComponent<TextMeshProUGUI>();
        textUI.SetText("Day " + CurrentDay + " - Year " + CurrentYear);

        for(int i=0; i<CalendarDays.Count; i++)
        {
            //current date has white background -- blue text
            if(i+1 == CurrentDay)
            {
                Image thisDay = CalendarDays[i].GetComponent<Image>();
                thisDay.GetComponent<Image>().color = new Color32(255,255,225,255);
                TMP_Text dayText = CalendarDays[i].transform.Find("Text").GetComponent<TMP_Text>();
                dayText.font = FontAssetBlue;
            }
            //days with a decision deadline or quest fullfillment deadline are red with white text
            else if(i+1 == DecisionDay[0] || i+1  == DecisionDay[1])
            {
                //TODO trigger decision prompt
                Image thisDay = CalendarDays[i].GetComponent<Image>();
                thisDay.GetComponent<Image>().color = new Color32(255,0,0,255);
                TMP_Text dayText = CalendarDays[i].transform.Find("Text").GetComponent<TMP_Text>();
                dayText.font = FontAssetWhite;
            }
             //all other days are black with white text
            else 
            {
                Image thisDay = CalendarDays[i].GetComponent<Image>();
                thisDay.GetComponent<Image>().color = new Color32(0,0,0,255);
                TMP_Text dayText = CalendarDays[i].transform.Find("Text").GetComponent<TMP_Text>();
                dayText.font = FontAssetWhite;
            }
        }
    }

    public void AddDecisionDay(int day)
    {
        DecisionDay.Add(day);
    }
                
    public void SetPanel(Tab tab)
    {
        Debug.Log("Setting panel");

        CanvasGroup mainCanva = MainPanel.GetComponent<CanvasGroup>();
        mainCanva.alpha = 1;
        mainCanva.blocksRaycasts = true;

        if (tab.tabType == Tab.TabType.Calendar)
        {
             foreach(GameObject panel in UIPanels)
             {
                 CanvasGroup canva = panel.GetComponent<CanvasGroup>();

                 if(panel.name == "CalendarUI")
                 {
                     canva.alpha = 1;
                     canva.blocksRaycasts = true;
                 } else{
                     canva.alpha = 0;
                     canva.blocksRaycasts = false;
                 }
             }
        }
        else if(tab.tabType == Tab.TabType.Mail)
        {
             foreach(GameObject panel in UIPanels)
             {
                 CanvasGroup canva = panel.GetComponent<CanvasGroup>();

                 if(panel.name == "MailUI")
                 {
                     canva.alpha = 1;
                     canva.blocksRaycasts = true;
                 } else{
                     canva.alpha = 0;
                     canva.blocksRaycasts = false;
                 }
             }
        }
    }

}
