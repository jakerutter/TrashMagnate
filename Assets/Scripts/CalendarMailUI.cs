using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalendarMailUI : MonoBehaviour
{
    private static int CurrentDay = 7;
    private static int CurrentYear = 1;
    private static List<int> DecisionDay = new List<int>() { 9, 13 };

    public GameObject CalendarIcon;
    public GameObject MailIcon;
    public List<GameObject> CalendarDays;
    public GameObject CalendarDate;
    public TMP_FontAsset FontAssetWhite;
    public TMP_FontAsset FontAssetBlue;

    void Start()
    {
        UpdateCalendarColors();
    }

    
    void Update()
    {
        
    }

    public int GetCurrentDay()
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

    private void UpdateCalendarColors()
    {
        for(int i=0; i<CalendarDays.Count; i++)
        {
            //current date has white background -- blue text
            if(i+1 == CurrentDay)
            {
                Debug.Log("Current day is " + i);
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
}
