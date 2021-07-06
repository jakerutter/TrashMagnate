using System;
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
        None,
    }

    public ItemType itemType;
    //public GameObject prefab;
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

    public GameObject GetPrefab()
    {
        switch (itemType)
        {
            default:
            case ItemType.PlasticBottle:        return ItemAssets.Instance.PlasticBottlePrefab;
            case ItemType.PlasticJug:           return ItemAssets.Instance.PlasticJugPrefab;
            case ItemType.GroceryBag:           return ItemAssets.Instance.GroceryBagPrefab;
            case ItemType.SmallTire:            return ItemAssets.Instance.SmallTirePrefab;
            case ItemType.LargeTire:            return ItemAssets.Instance.LargeTirePrefab;
            case ItemType.Shoe:                 return ItemAssets.Instance.ShoePrefab;
            case ItemType.Boot:                 return ItemAssets.Instance.BootPrefab;
            case ItemType.NewsPaper:            return ItemAssets.Instance.NewsPaperPrefab;
            case ItemType.Book:                 return ItemAssets.Instance.GetRandomBookPrefab();
            case ItemType.Box:                  return ItemAssets.Instance.BoxPrefab;
            case ItemType.Computer:             return ItemAssets.Instance.ComputerPrefab;
            case ItemType.CellPhone:            return ItemAssets.Instance.CellPhonePrefab;
            case ItemType.Fan:                  return ItemAssets.Instance.FanPrefab;
            case ItemType.SmallBattery:         return ItemAssets.Instance.SmallBatteryPrefab;
            case ItemType.LargeBattery:         return ItemAssets.Instance.LargeBatteryPrefab;
            case ItemType.SmallWood:            return ItemAssets.Instance.SmallWoodPrefab;
            case ItemType.LargeWood:            return ItemAssets.Instance.LargeWoodPrefab;
            case ItemType.Can:                  return ItemAssets.Instance.CanPrefab;
            case ItemType.BrownGlassBottle:     return ItemAssets.Instance.BrownGlassBottlePrefab;
            case ItemType.GreenGlassBottle:     return ItemAssets.Instance.GreenGlassBottlePrefab;
            case ItemType.GrowlerBottle:        return ItemAssets.Instance.GrowlerBottlePrefab;
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
            case ItemType.BrownGlassBottle:     
            case ItemType.GreenGlassBottle:     
            case ItemType.GrowlerBottle:   
            return true;      
                //the  above should be stackable, it is just this way for an example
        }
    }

    public bool CanRecycle()
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
            case ItemType.BrownGlassBottle:     
            case ItemType.GreenGlassBottle:     
            case ItemType.GrowlerBottle:   
                return true;
        }
    }

    public int RecycleRequirement()
    {
        switch(itemType)
        {
            default:
            case ItemType.PlasticBottle:        
            case ItemType.PlasticJug:          
            case ItemType.GroceryBag:           
            case ItemType.SmallTire:
            case ItemType.Shoe:                
            case ItemType.Boot:                 
            case ItemType.NewsPaper:
            case ItemType.Box:                                 
            case ItemType.SmallBattery:        
            case ItemType.LargeBattery:
            case ItemType.SmallWood:  
            case ItemType.Can:             
            case ItemType.BrownGlassBottle:     
            case ItemType.GreenGlassBottle:
                return 1;          
            case ItemType.LargeTire:            
            case ItemType.Book:                        
            case ItemType.LargeWood:            
            case ItemType.GrowlerBottle:  
            case ItemType.Computer:          
            case ItemType.CellPhone:
            case ItemType.Fan:   
                return 2;     
        }
    }

    public RecyclingQuest.RawType GetItemRawType()
    {
        switch(itemType)
        {
            default:
            case ItemType.PlasticBottle:        
            case ItemType.PlasticJug:
            case ItemType.GroceryBag:
                return RecyclingQuest.RawType.Plastic;          
                       
            case ItemType.SmallTire:
            case ItemType.LargeTire:
            case ItemType.Shoe:                
            case ItemType.Boot:  
                return RecyclingQuest.RawType.Rubber;

            case ItemType.NewsPaper:
            case ItemType.Box:
            case ItemType.Book:
                return RecyclingQuest.RawType.Paper;

            case ItemType.Computer:          
            case ItemType.CellPhone:           
            case ItemType.Fan:                  
            case ItemType.SmallBattery:        
            case ItemType.LargeBattery:
                return RecyclingQuest.RawType.Electronic;

            case ItemType.SmallWood:
            case ItemType.LargeWood:
                return RecyclingQuest.RawType.Wood;

            case ItemType.Can:
                return RecyclingQuest.RawType.Metal;

            case ItemType.BrownGlassBottle:     
            case ItemType.GreenGlassBottle:
            case ItemType.GrowlerBottle:
                return RecyclingQuest.RawType.Glass;   
        }
    }

    public float GetRawMass()
    {
        switch (itemType)
        {
            default:
            case ItemType.PlasticBottle:        return .6f;
            case ItemType.PlasticJug:           return 2f;
            case ItemType.GroceryBag:           return .2f;
            case ItemType.SmallTire:            return 2f;
            case ItemType.LargeTire:            return 5f;
            case ItemType.Shoe:                 return .4f;
            case ItemType.Boot:                 return .6f;
            case ItemType.NewsPaper:            return .4f;
            case ItemType.Book:                 return 2f;
            case ItemType.Box:                  return .6f;
            case ItemType.Computer:             return 2f;
            case ItemType.CellPhone:            return .6f;
            case ItemType.Fan:                  return 3f;
            case ItemType.SmallBattery:         return .2f;
            case ItemType.LargeBattery:         return 4f;
            case ItemType.SmallWood:            return 1f;
            case ItemType.LargeWood:            return 3f;
            case ItemType.Can:                  return .2f;
            case ItemType.BrownGlassBottle:     return .6f;
            case ItemType.GreenGlassBottle:     return .6f;
            case ItemType.GrowlerBottle:        return 1f;

        }
    }

    public string GetName()
    {
        switch (itemType)
        {
            default:
            case ItemType.PlasticBottle:        return "Plastic Bottles";
            case ItemType.PlasticJug:           return "Plastic Jugs";
            case ItemType.GroceryBag:           return "Grocery Bags";
            case ItemType.SmallTire:            return "Small Tires";
            case ItemType.LargeTire:            return "Large Tires";
            case ItemType.Shoe:                 return "Shoes";
            case ItemType.Boot:                 return "Boots";
            case ItemType.NewsPaper:            return "Newspapers";
            case ItemType.Book:                 return "Books";
            case ItemType.Box:                  return "Boxes";
            case ItemType.Computer:             return "Computers";
            case ItemType.CellPhone:            return "Cell Phones";
            case ItemType.Fan:                  return "Fans";
            case ItemType.SmallBattery:         return "Small Batteries";
            case ItemType.LargeBattery:         return "Large Batteries";
            case ItemType.SmallWood:            return "Small Chunks of Wood";
            case ItemType.LargeWood:            return "Large Wood Planks";
            case ItemType.Can:                  return "Aluminum Cans";
            case ItemType.BrownGlassBottle:     return "Brown Glass Bottles";
            case ItemType.GreenGlassBottle:     return "Green Glass Bottles";
            case ItemType.GrowlerBottle:        return "Growler Bottle";
            case ItemType.None:            return "None";

        }
    }

  
}
