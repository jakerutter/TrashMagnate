﻿using System.Collections;
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
    public Transform pfRecyclerWorld;

    public Sprite PlasticBottleSprite;
    public Sprite PlasticJugSprite;
    public Sprite GroceryBagSprite;
    public Sprite SmallTireSprite;
    public Sprite LargeTireSprite;
    public Sprite ShoeSprite;
    public Sprite BootSprite;
    public Sprite NewsPaperSprite;
    public Sprite BookSprite;
    public Sprite BookFlippedSprite;
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
    public Sprite BasicRecyclerSprite;
    public Sprite ModernRecyclerSprite;
    public Sprite AdvancedRecyclerSprite;
    public Sprite BlackCubeSprite;
    public Sprite BlackCubeFlippedSprite;
    public Sprite TrophySprite;
    public Sprite GraphSprite;
    public Sprite GraphFlippedSprite;
    public Sprite RecycleSprite;
    public Sprite CheckSprite;
    public Sprite WrenchSprite;
    public Sprite WrenchFlippedSprite;
    public Sprite BackpackSprite;
    public Sprite BackpackFlippedSprite;
    public Sprite WoodTitleSprite;
    public Sprite PurchaseHandSprite;
    public Sprite LockSprite;

    public GameObject PlasticBottlePrefab;
    public GameObject LaptopPrefab;
    public GameObject SoupCanPrefab;
    public GameObject CanPrefab;
}
