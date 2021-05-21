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
}