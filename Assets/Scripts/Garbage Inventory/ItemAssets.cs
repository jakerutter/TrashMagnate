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
    public Sprite PotSprite;  //need this sprite
    public Sprite PanSprite; //need this sprite
    public Sprite LargeBatterySprite;
    public Sprite PalletSprite;  //need this sprite
    public Sprite PlankSprite;
    public Sprite CrateSprite;  //need this sprite
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
    public Sprite CalendarSprite;
    public Sprite MailSprite;
    public Sprite RTLogo;

    public GameObject PlasticBottlePrefab;
 
    public GameObject PlasticJugPrefab;
    public GameObject GroceryBagPrefab;
    public GameObject SmallTirePrefab;
    public GameObject LargeTirePrefab;
    public GameObject ShoePrefab;
    public GameObject BootPrefab;
    public GameObject NewsPaperPrefab;
    public GameObject BookPrefab1;
    public GameObject BookPrefab2;
    public GameObject BookPrefab3;
    public GameObject BookPrefab4;
    public GameObject BoxPrefab;
    public GameObject BoxPrefab2;
    public GameObject ComputerPrefab;
    public GameObject CellPhonePrefab;
    public GameObject FanPrefab;
    public GameObject PotPrefab;
    public GameObject PanPrefab;
    public GameObject LargeBatteryPrefab;
    public GameObject PalletPrefab;
    public GameObject PlankPrefab;
    public GameObject CratePrefab;
    public GameObject CanPrefab;
    public GameObject BrownGlassBottlePrefab;
    public GameObject GreenGlassBottlePrefab;
    public GameObject GrowlerBottlePrefab;
    public GameObject BasicRecyclerPrefab;
    public GameObject ModernRecyclerPrefab;
    public GameObject AdvancedRecyclerPrefab;
    public GameObject SoupCanPrefab;

    public GameObject GetRandomBookPrefab()
    {
        System.Random rd = new System.Random();

        int rand_num = rd.Next(1, 5);

        if (rand_num == 1)
        {
            return Instance.BookPrefab1;
        }
        else if (rand_num == 2)
        {
            return Instance.BookPrefab2;
        }
        else if (rand_num == 3)
        {
            return Instance.BookPrefab3;
        }
        else
        {
            return Instance.BookPrefab4;
        }
    }
}
