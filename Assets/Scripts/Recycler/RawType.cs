// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class RawType : MonoBehaviour
// {
//    public static RawType Instance { get; private set; }

//     public enum RawType {
//         Plastic,
//         PlasticJug,
//         GroceryBag,
//         SmallTire,
//         LargeTire,
//         Shoe,
//         Boot,
//         NewsPaper,
//         Book,
//         Box,
//         Computer,
//         CellPhone,
//         Fan,
//         SmallBattery,
//         LargeBattery,
//         SmallWood,
//         LargeWood,
//         Can,
//         BrownGlassBottle,
//         GreenGlassBottle,
//         GrowlerBottle,
//     }

//     public ItemType itemType;
//    private void Awake()
//    {
//        Instance = this;
//    }

//     public string RawTypeName()
//     {
//         switch(itemType)
//         {
//             default:
//             case ItemType.PlasticBottle:        
//             case ItemType.PlasticJug:
//             case ItemType.GroceryBag:
//                 return "Plastic";          
                       
//             case ItemType.SmallTire:
//             case ItemType.LargeTire:
//             case ItemType.Shoe:                
//             case ItemType.Boot:  
//                 return "Rubber";

//             case ItemType.NewsPaper:
//             case ItemType.Box:
//             case ItemType.Book:
//                 return "Paper";

//             case ItemType.Computer:          
//             case ItemType.CellPhone:           
//             case ItemType.Fan:                  
//             case ItemType.SmallBattery:        
//             case ItemType.LargeBattery:
//                 return "Electronic";

//             case ItemType.SmallWood:
//             case ItemType.LargeWood:
//                 return "Wood";

//             case ItemType.Can:
//                 return "Metal";

//             case ItemType.BrownGlassBottle:     
//             case ItemType.GreenGlassBottle:
//             case ItemType.GrowlerBottle:
//                 return "Glass";   
//         }
//     }

//      public float GetRawMass()
//     {
//         switch (itemType)
//         {
//             default:
//             case ItemType.PlasticBottle:        return .5f;
//             case ItemType.PlasticJug:           return 2f;
//             case ItemType.GroceryBag:           return .25f;
//             case ItemType.SmallTire:            return 2f;
//             case ItemType.LargeTire:            return 5f;
//             case ItemType.Shoe:                 return .25f;
//             case ItemType.Boot:                 return .5f;
//             case ItemType.NewsPaper:            return .25f;
//             case ItemType.Book:                 return 2f;
//             case ItemType.Box:                  return .5f;
//             case ItemType.Computer:             return 1f;
//             case ItemType.CellPhone:            return .25f;
//             case ItemType.Fan:                  return 2f;
//             case ItemType.SmallBattery:         return .25f;
//             case ItemType.LargeBattery:         return 4f;
//             case ItemType.SmallWood:            return 1f;
//             case ItemType.LargeWood:            return 3f;
//             case ItemType.Can:                  return .25f;
//             case ItemType.BrownGlassBottle:     return .25f;
//             case ItemType.GreenGlassBottle:     return .25f;
//             case ItemType.GrowlerBottle:        return .5f;

//         }
//     }
// }
