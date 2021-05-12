using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Recycler : MonoBehaviour
{
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
    private bool isRecyclerCursor = false;

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Selecting item "+ this.gameObject.name);

            if(recycleInventoryToggle != null)
            {
                recycleInventoryToggle.onClick.Invoke();
                Cursor.SetCursor(recycleCursor, new Vector2(16,16), CursorMode.Auto);
            }
        }
    }

}