using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using CodeMonkey.Utils;

public class UISwitcher : MonoBehaviour
{
    public Image titleImage;
    public Image titleImage2;
    public TextMeshProUGUI titleText;
    public List<Tab> tabs;
    public List<GameObject> tabPanels;

    private void Start()
    {
        foreach (Tab tab in tabs)
        {
            tab.GetComponent<Button_UI>().ClickFunc = () => {
                SetTab(tab);
                SetPanel(tab);
            };
        }
    }

    public void SetTab(Tab tab)
    {
        if (tab.tabType == Tab.TabType.InventoryItems)
        {
            titleText.SetText("Item Inventory");
            titleImage.sprite = ItemAssets.Instance.BackpackFlippedSprite; 
            titleImage2.sprite = ItemAssets.Instance.BackpackSprite;    
        }
        else if (tab.tabType == Tab.TabType.RawResources)
        {
            titleText.SetText("Raw Resources"); 
            titleImage.sprite = ItemAssets.Instance.BlackCubeFlippedSprite;
            titleImage2.sprite = ItemAssets.Instance.BlackCubeSprite;
        }
        else if (tab.tabType == Tab.TabType.QuestLog)
        {
            titleText.SetText("Quest Log"); 
            titleImage.sprite = ItemAssets.Instance.BookFlippedSprite;
            titleImage2.sprite = ItemAssets.Instance.BookSprite;
        }
        else if (tab.tabType == Tab.TabType.BuildLog)
        {
            titleText.SetText("Build Log");
            titleImage.sprite = ItemAssets.Instance.WrenchFlippedSprite;
            titleImage2.sprite = ItemAssets.Instance.WrenchSprite;
        }
        else if (tab.tabType == Tab.TabType.Collectables)
        {
            titleText.SetText("Collectables"); 
            titleImage.sprite = ItemAssets.Instance.TrophySprite;
            titleImage2.sprite = ItemAssets.Instance.TrophySprite;
        }
        else if (tab.tabType == Tab.TabType.Stats)
        {
            titleText.SetText("Game Stats"); 
            titleImage.sprite = ItemAssets.Instance.GraphFlippedSprite;
            titleImage2.sprite = ItemAssets.Instance.GraphSprite;
        }
    }

      public void SetPanel(Tab tab)
    {
        if (tab.tabType == Tab.TabType.InventoryItems)
        {
             foreach(GameObject panel in tabPanels)
             {
                 if(panel.name == "InventoryUI")
                 {
                     panel.GetComponent<CanvasGroup>().alpha = 1;
                 } else{
                     panel.GetComponent<CanvasGroup>().alpha = 0;
                 }
             }
        }
        else if (tab.tabType == Tab.TabType.RawResources)
        {
            foreach(GameObject panel in tabPanels)
             {
                 if(panel.name == "RawResourcesUI")
                 {
                     panel.GetComponent<CanvasGroup>().alpha = 1;
                 } else{
                     panel.GetComponent<CanvasGroup>().alpha = 0;
                 }
             }
        }
        else if (tab.tabType == Tab.TabType.QuestLog)
        {
            foreach(GameObject panel in tabPanels)
             {
                 if(panel.name == "QuestLogUI")
                 {
                     panel.GetComponent<CanvasGroup>().alpha = 1;
                 } else{
                     panel.GetComponent<CanvasGroup>().alpha = 0;
                 }
             }
        }
        else if (tab.tabType == Tab.TabType.BuildLog)
        {
            foreach(GameObject panel in tabPanels)
             {
                 if(panel.name == "BuildLogUI")
                 {
                     panel.GetComponent<CanvasGroup>().alpha = 1;
                 } else{
                     panel.GetComponent<CanvasGroup>().alpha = 0;
                 }
             }
        }
        else if (tab.tabType == Tab.TabType.Collectables)
        {
           foreach(GameObject panel in tabPanels)
             {
                 Debug.Log(panel.name);
                 if(panel.name == "CollectablesUI")
                 {
                     panel.GetComponent<CanvasGroup>().alpha = 1;
                 } else{
                     panel.GetComponent<CanvasGroup>().alpha = 0;
                 }
             }
        }
        else if (tab.tabType == Tab.TabType.Stats)
        {
            foreach(GameObject panel in tabPanels)
             {
                 if(panel.name == "StatsUI")
                 {
                     panel.GetComponent<CanvasGroup>().alpha = 1;
                 } else{
                     panel.GetComponent<CanvasGroup>().alpha = 0;
                 }
             }
        }
    }
}
