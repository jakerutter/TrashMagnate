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

    private void Start()
    {
        foreach (Tab tab in tabs)
        {
            tab.GetComponent<Button_UI>().ClickFunc = () => {
                SetTab(tab);
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
}
