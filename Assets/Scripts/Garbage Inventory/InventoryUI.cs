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

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");

        if(itemSlotContainer != null)
        {
            itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
        }
    }

    private void Start()
    {
        if(itemSlotContainer == null)
        {
            Debug.Log("Item slot container was null in awake");
            itemSlotContainer = transform.Find("ItemSlotContainer");
        }

        if(itemSlotTemplate == null)
        {
            itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
        }
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void SetInventory(Inventory inventory)
    {
       this.inventory = inventory;

       inventory.OnItemListChanged += Inventory_OnItemListChanged;
       //recently uncommented the below line 
       RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        if(itemSlotContainer == null){
            Debug.Log("item slot container is null in refreshInventoryItems");
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
}
