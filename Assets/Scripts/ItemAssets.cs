using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
   public static ItemAssets Instance { get; private set; }

   private void Awake()
   {
       Instance = this;
   }

    public Transform pfItemWorld;

    public Sprite PlasticBottleSprite;
    public Sprite PlasticJugSprite;
    public Sprite GroceryBagSprite;
    public Sprite SmallTireSprite;
    public Sprite LargeTireSprite;
    public Sprite ShoeSprite;
    public Sprite BootSprite;
    public Sprite NewsPaperSprite;
    public Sprite BookSprite;
    public Sprite BoxSprite;
    public Sprite ComputerSprite;
    public Sprite CellPhoneSprite;
    public Sprite FanSprite;
    public Sprite SmallBatterySprite;
    public Sprite LargeBatterySprite;
    public Sprite SmallWoodSprite;
    public Sprite LargeWoodSprite;
    public Sprite CanSprite;
    public Sprite BrownGlassBottleSprite;
    public Sprite GreenGlassBottleSprite;
    public Sprite GrowlerBottleSprite;
}
