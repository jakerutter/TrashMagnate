using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Tab : MonoBehaviour
{
    public enum TabType {
        InventoryItems,
        RawResources,
        QuestLog,
        BuildLog,
        Collectables,
        Stats,
    }

    public TabType tabType;

    public Sprite GetSprite()
    {
        switch (tabType)
        {
            default:
            case TabType.InventoryItems:            return ItemAssets.Instance.PlasticJugSprite;
            case TabType.RawResources:              return ItemAssets.Instance.BlackCubeSprite;
            case TabType.QuestLog:                  return ItemAssets.Instance.BookSprite;
            case TabType.BuildLog:                  return ItemAssets.Instance.WrenchSprite;
            case TabType.Collectables:              return ItemAssets.Instance.TrophySprite;
            case TabType.Stats:                     return ItemAssets.Instance.GraphSprite;

        }
    }

}