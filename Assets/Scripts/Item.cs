using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType {
        PlasticBottle,
        PlasticJug,
        GroceryBag,
        SmallTire,
        LargeTire,
        Shoe,
        Boot,
        NewsPaper,
        Book,
        Box,
        Computer,
        CellPhone,
        Fan,
        SmallBattery,
        LargeBattery,
        SmallWood,
        LargeWood,
        Can,
        BrownGlassBottle,
        GreenGlassBottle,
        GrowlerBottle,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.PlasticBottle:        return ItemAssets.Instance.PlasticBottleSprite;
            case ItemType.PlasticJug:           return ItemAssets.Instance.PlasticJugSprite;
            case ItemType.GroceryBag:           return ItemAssets.Instance.GroceryBagSprite;
            case ItemType.SmallTire:            return ItemAssets.Instance.SmallTireSprite;
            case ItemType.LargeTire:            return ItemAssets.Instance.LargeTireSprite;
            case ItemType.Shoe:                 return ItemAssets.Instance.ShoeSprite;
            case ItemType.Boot:                 return ItemAssets.Instance.BootSprite;
            case ItemType.NewsPaper:            return ItemAssets.Instance.NewsPaperSprite;
            case ItemType.Book:                 return ItemAssets.Instance.BookSprite;
            case ItemType.Box:                  return ItemAssets.Instance.BoxSprite;
            case ItemType.Computer:             return ItemAssets.Instance.ComputerSprite;
            case ItemType.CellPhone:            return ItemAssets.Instance.CellPhoneSprite;
            case ItemType.Fan:                  return ItemAssets.Instance.FanSprite;
            case ItemType.SmallBattery:         return ItemAssets.Instance.SmallBatterySprite;
            case ItemType.LargeBattery:         return ItemAssets.Instance.LargeBatterySprite;
            case ItemType.SmallWood:            return ItemAssets.Instance.SmallWoodSprite;
            case ItemType.LargeWood:            return ItemAssets.Instance.LargeWoodSprite;
            case ItemType.Can:                  return ItemAssets.Instance.CanSprite;
            case ItemType.BrownGlassBottle:     return ItemAssets.Instance.BrownGlassBottleSprite;
            case ItemType.GreenGlassBottle:     return ItemAssets.Instance.GreenGlassBottleSprite;
            case ItemType.GrowlerBottle:        return ItemAssets.Instance.GrowlerBottleSprite;

        }
    }

    public bool IsStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.PlasticBottle:        
            case ItemType.PlasticJug:          
            case ItemType.GroceryBag:           
            case ItemType.SmallTire:          
            case ItemType.LargeTire:            
            case ItemType.Shoe:                
            case ItemType.Boot:                 
            case ItemType.NewsPaper:            
            case ItemType.Book:              
            case ItemType.Box:                 
            case ItemType.Computer:          
            case ItemType.CellPhone:           
            case ItemType.Fan:                  
            case ItemType.SmallBattery:        
            case ItemType.LargeBattery:         
            case ItemType.SmallWood:            
            case ItemType.LargeWood:            
            case ItemType.Can:
                return true;                 
            case ItemType.BrownGlassBottle:     
            case ItemType.GreenGlassBottle:     
            case ItemType.GrowlerBottle:   
                return false;     
        }
    }
}
