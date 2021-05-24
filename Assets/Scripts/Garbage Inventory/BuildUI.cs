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
    private Inventory inventory;
    private Player player;
    private Transform recycleSlotContainer;
    private Transform recycleSlotTemplate;

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

    public void SetInventory(Inventory inventory)
    {
        //Debug.Log("Calling SetInventory. Inv item count = " + inventory.GetItemList().Count);

       this.inventory = inventory;

       inventory.OnItemListChanged += Inventory_OnItemListChanged;
       
       RefreshInventoryItems();
       RefreshRecycleInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
        RefreshRecycleInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        //Debug.Log("Refreshing Inventory Items");
        if(buildSlotContainer == null){
            //Debug.Log("item slot container is null in refreshInventoryItems");
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
        float itemSlotCellSize = 110f;

        foreach (Item item in inventory.GetItemList())
        {       
            RectTransform itemSlotRectTransform = Instantiate(buildSlotTemplate, buildSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                //use item (convert to raw or place in recycler)
                inventory.UseItem(item);
                //Debug.Log("raw type is " + item.RawType());
                //Debug.Log("mass is " + item.GetRawMass());

            };
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => {
                //drop item
                Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
                inventory.RemoveItem(item);
                ItemWorld.DropItem(player.GetPosition(), duplicateItem);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            if(item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());   
            } else {
                uiText.SetText("");
            }
            
            x++;

            if(x > 10)
            {
                x=0;
                y--;
            }
        }
    }

    private void RefreshRecycleInventoryItems()
    {
        foreach(Transform child in recycleSlotContainer)
        {
            if (child == recycleSlotTemplate)
            {
                continue;
            }
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 110f;

        foreach (Item item in inventory.GetItemList())
        {

            // Debug.Log("item name is " + item.itemType);
            // Debug.Log("skill = " + RecyclingInventory.GetRecyclingSkill() + ". requirement = " + item.RecycleRequirement());

            if(item.CanRecycle() == false)
            {
                Debug.Log("skipping item, cannot recycle");
                continue;
            }

            RectTransform itemSlotRectTransform = Instantiate(recycleSlotTemplate, recycleSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                //use item (convert to raw or place in recycler)
                inventory.RecycleItem(item);
            };
            // itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => {
            //     //drop item
            //     Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
            //     inventory.RemoveItem(item);
            //     ItemWorld.DropItem(player.GetPosition(), duplicateItem);
            // };

        itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
        Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
        image.sprite = item.GetSprite();
        
        TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
        if(item.amount > 1)
        {
            uiText.SetText(item.amount.ToString());   
        } else {
            uiText.SetText("");
        }

        //if player's recycling skill is high enough to recycle, highlight item green
        if(RecyclingInventory.GetRecyclingSkill() >= item.RecycleRequirement())
        {
            GameObject rc = recycleSlotTemplate.gameObject;
            Outline outline = rc.GetComponent<Outline>(); 
            outline.enabled = true;
        }

            x++;

            if(x > 4)
            {
                x=0;
                y--;
            }
        }
    }
}
