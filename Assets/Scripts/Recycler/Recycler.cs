using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[Serializable]
public class Recycler : MonoBehaviour
{
    public enum RecyclerType
    {
        BasicRecycler,
        ModernRecycler,
        AdvancedRecycler,
    }

    public RecyclerType recyclerType;

    // Need to know what objects are clickable
    //Need to swap cursors per object type
    public LayerMask clickableLayer;
    public Texture2D pointer; // normal pointer
    public Texture2D recycleCursor; // recycle pointer
    public EventVector3 OnClickEnvironment;
    public Button recycleInventoryToggle;

    private GameObject selectedObject;
    private float startPosX;
    private float startPosY;

    private void Start()
    {
        SpriteRenderer render = this.GetComponent<SpriteRenderer>();
        render.sprite = GetSprite();
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Selecting item "+ this.gameObject.name);

            if(recycleInventoryToggle != null)
            {
                recycleInventoryToggle.onClick.Invoke();
                Cursor.SetCursor(recycleCursor, new Vector2(16,16), CursorMode.Auto);
            }
        }
    }

    public float GetYield()
    {
        switch (recyclerType)
        {
            default:
            case RecyclerType.BasicRecycler:        return .25f;
            case RecyclerType.ModernRecycler:       return .5f;
            case RecyclerType.AdvancedRecycler:     return .75f;
        }
    }

    public Sprite GetSprite()
    {
        switch (recyclerType)
        {
            default:
            case RecyclerType.BasicRecycler:        return ItemAssets.Instance.BasicRecyclerSprite;
            case RecyclerType.ModernRecycler:       return ItemAssets.Instance.ModernRecyclerSprite;
            case RecyclerType.AdvancedRecycler:     return ItemAssets.Instance.AdvancedRecyclerSprite;
        }
    }

    public string GetName()
    {
        switch (recyclerType)
        {
            default:
            case RecyclerType.BasicRecycler:        return "Basic Recycler";
            case RecyclerType.ModernRecycler:       return "Modern Recycler";
            case RecyclerType.AdvancedRecycler:     return "Advanced Recycler";
        }
    }

    public List<Item> GetCost()
    {
        switch (recyclerType)
        {
            default:
            case RecyclerType.BasicRecycler:        return new List<Item>()
                {
                    new Item(){ itemType = Item.ItemType.Can, amount = 15 },
                    new Item(){ itemType = Item.ItemType.BrownGlassBottle, amount = 15 },
                    new Item(){ itemType = Item.ItemType.SmallTire, amount = 5 },
                    new Item(){ itemType = Item.ItemType.Box, amount = 5 }
                };

            case RecyclerType.ModernRecycler:       return new List<Item>()
                {
                    new Item(){ itemType = Item.ItemType.SmallBattery, amount = 10 },
                    new Item(){ itemType = Item.ItemType.GrowlerBottle, amount = 10 },
                    new Item(){ itemType = Item.ItemType.LargeTire, amount = 20 },
                    new Item(){ itemType = Item.ItemType.Book, amount = 20 }
                };
            //TODO make advanced and rare items required for this upgrade
            case RecyclerType.AdvancedRecycler:     return new List<Item>()
                {
                    new Item(){ itemType = Item.ItemType.Can, amount = 15 },
                    new Item(){ itemType = Item.ItemType.BrownGlassBottle, amount = 15 },
                    new Item(){ itemType = Item.ItemType.SmallTire, amount = 5 },
                    new Item(){ itemType = Item.ItemType.Box, amount = 5 }
                };
        }
    }

    public bool GetUnlocked()
    {
        switch (recyclerType)
        {
            default:
            case RecyclerType.BasicRecycler:        return false;
            case RecyclerType.ModernRecycler:       return RecyclingInventory.GetBasicRecyclerBuilt();
            case RecyclerType.AdvancedRecycler:     return RecyclingInventory.GetModernRecyclerBuilt();
        }
    }
}