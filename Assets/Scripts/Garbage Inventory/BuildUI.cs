using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class BuildUI : MonoBehaviour
{
    private Transform buildSlotContainer;
    private Transform buildSlotTemplate;
    private BuildingInventory buildingInventory;
    private Player player;

    private void Awake()
    {
        buildSlotContainer = transform.Find("BuildSlotContainer");

        if(buildSlotContainer != null)
        {
            buildSlotTemplate = buildSlotContainer.Find("BuildSlotTemplate");
        }
    }

    private void Start()
    {
        if(buildSlotContainer == null)
        {
            buildSlotContainer = transform.Find("BuildSlotContainer");
        }

        if(buildSlotTemplate == null)
        {
            if(buildSlotContainer == null) {return;}
            buildSlotTemplate = buildSlotContainer.Find("BuildSlotTemplate");
        }
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void SetBuildingInventory(BuildingInventory buildingInventory)
    {
        //Debug.Log("Calling SetBuildInventory. Inv item count = " + buildingInventory.GetBuildingList().Count);

       this.buildingInventory = buildingInventory;
        //TODO below line should be un commented but was throwing an error
       buildingInventory.OnBuildingListChanged += BuildingInventory_OnBuildingListChanged;
       
       RefreshBuildingInventory();  
    }

       private void RefreshBuildingInventory()
    {
        //Debug.Log("Refreshing BuildInventory Items");
        if(buildSlotContainer == null){
            //Debug.Log("item slot container is null in RefreshBuildingInventory");
        }
        
        foreach(Transform child in buildSlotContainer)
        {
            if (child == buildSlotTemplate)
            {
                continue;
            }
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float buildSlotCellSize = 190f;

        foreach (Recycler recycler in buildingInventory.GetBuildingList())
        {       
            Debug.Log(buildingInventory.GetBuildingList().Count + " is building list count");
            
            RectTransform buildSlotRectTransform = Instantiate(buildSlotTemplate, buildSlotContainer).GetComponent<RectTransform>();
            buildSlotRectTransform.gameObject.SetActive(true);

            buildSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                //use item (convert to raw or place in recycler)
                buildingInventory.UseBuilding(recycler);
                //Debug.Log("raw type is " + item.RawType());
                //Debug.Log("mass is " + item.GetRawMass());

            };
            // buildSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => {
            //     //drop item
            //     Recycler dupeRecycler = new Recycler { recyclerType = recycler.recyclerType };
            //     buildingInventory.RemoveItem(recycler);
            //     ItemWorld.DropItem(player.GetPosition(), duplicateItem);
            // };

            buildSlotRectTransform.anchoredPosition = new Vector2(x * buildSlotCellSize, y * buildSlotCellSize);
            Image image = buildSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = recycler.GetSprite();
            
            x++;

            if(x > 10)
            {
                x=0;
                y--;
            }
        }
    }

     private void BuildingInventory_OnBuildingListChanged(object sender, System.EventArgs e)
    {
        RefreshBuildingInventory();
    }
}
