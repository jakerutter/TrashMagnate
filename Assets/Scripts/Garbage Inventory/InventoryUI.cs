using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class InventoryUI : MonoBehaviour
{
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Inventory inventory;
    private Player player;
    private Transform recycleSlotContainer;
    private Transform recycleSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");

        if(itemSlotContainer != null)
        {
            itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
        }

        //recyclerInventory UI items
        recycleSlotContainer = GameObject.FindGameObjectWithTag("RecycleSlotContainer").transform;

        if(recycleSlotContainer != null)
        {
          recycleSlotTemplate = recycleSlotContainer.transform.Find("RecycleSlotTemplate");  
        }
    }

    private void Start()
    {
        if(itemSlotContainer == null)
        {
            itemSlotContainer = transform.Find("ItemSlotContainer");
        }

        if(itemSlotTemplate == null)
        {
            if(itemSlotContainer == null) {return;}
            itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
        }

        //recyclerInventory UI items
        if(recycleSlotContainer == null)
        {
            recycleSlotContainer = GameObject.FindGameObjectWithTag("RecycleSlotContainer").transform;
        }
         
        if(recycleSlotTemplate == null)
        {
            if(recycleSlotContainer == null){return;}
            recycleSlotTemplate = recycleSlotContainer.transform.Find("RecycleSlotTemplate");  
        }

         //Display current RT point total
        GameObject RecyclingTechPoints = GameObject.FindGameObjectWithTag("RTPointDisplay");
        RecyclingTechPoints.GetComponent<TextMeshProUGUI>().SetText(RecyclingInventory.GetRecyclingTechPoints().ToString());
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void SetInventory(Inventory inventory)
    {
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
        if(itemSlotContainer == null){
            //Debug.Log("item slot container is null in refreshInventoryItems");
        }
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate)
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
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
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

    public void RefreshRecycleInventoryItems()
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
            GameObject rc = itemSlotRectTransform.gameObject;
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
