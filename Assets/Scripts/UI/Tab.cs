using UnityEngine;

public class Tab : MonoBehaviour
{
    public enum TabType {
        InventoryItems,
        RawResources,
        QuestLog,
        BuildLog,
        Collectables,
        Stats,
        TechTree,
        Calendar,
        Mail

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
            case TabType.Calendar:                  return ItemAssets.Instance.CalendarSprite;
            case TabType.Mail:                      return ItemAssets.Instance.MailSprite;
            case TabType.TechTree:                  return ItemAssets.Instance.RTLogo;

        }
    }

    public string GetFriendlyName()
    {
        switch (tabType)
        {
            default:
            case TabType.InventoryItems: return "Inventory Items";
            case TabType.RawResources: return "Raw Resources";
            case TabType.QuestLog: return "Quest Log";
            case TabType.BuildLog: return "Build Log";
            case TabType.Collectables: return "Collectables";
            case TabType.Stats: return "Stats";
            case TabType.Calendar: return "Calendar";
            case TabType.Mail: return "Mail";
            case TabType.TechTree: return "Tech Tree";

        }
    }

}