using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class RecycleInventoryUI : MonoBehaviour
{

    private Transform recycleSlotContainer;
    private Transform recycleSlotTemplate;
    private Inventory inventory;
    private RecyclerInventory recyclerInventory;
    private Player player;

    private void Awake()
    {
        recycleSlotContainer = transform.Find("RecycleSlotContainer");
        recycleSlotTemplate = recycleSlotContainer.Find("RecycleSlotTemplate");
    }

    private void Start()
    {
        if(recycleSlotContainer == null)
        {
            Debug.Log("Item slot container was null in awake");
            recycleSlotContainer = transform.Find("RecycleSlotContainer");
        }

        if(recycleSlotTemplate == null)
        {
            recycleSlotTemplate = recycleSlotContainer.Find("RecycleSlotTemplate");
        }
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void SetRecycleInventory(Inventory inventory)
    {
       this.inventory = inventory;

       inventory.OnItemListChanged += Inventory_OnItemListChanged;
       //recently uncommented the below line 
       RefreshRecycleInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshRecycleInventoryItems();
    }

    private void RefreshRecycleInventoryItems()
    {
        if(recycleSlotContainer == null){
            Debug.Log("item slot container is null in refreshInventoryItems");
        }
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

            if(item.CanRecycle() == false)
            {
                // itemList.Remove(item);
                continue;
            }

            RectTransform itemSlotRectTransform = Instantiate(recycleSlotTemplate, recycleSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                //use item (convert to raw or place in recycler)
                inventory.UseItem(item);
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
            
        x++;

        if(x > 8)
        {
            x=0;
            y--;
        }
        }
    }
}
