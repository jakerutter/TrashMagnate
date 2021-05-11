using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    // Need to know what objects are clickable
    //Need to swap cursors per object type
    public LayerMask clickableLayer;
    public Texture2D pointer; // normal pointer
    public Texture2D target; // target pointer
    //public Texture2D doorway; // actions pointer
    public EventVector3 OnClickEnvironment;
    
    //inventory toggle buttons
    public Button mainInventoryToggle;
    public Button questInventoryToggle;
    public Button rawInventoryToggle;

    private GameObject selectedObject;
    private float startPosX;
    private float startPosY;
    private bool isBegingHeld = false;

    void Start()
    {
        Cursor.SetCursor(pointer, new Vector2(16,16), CursorMode.Auto);
    }

    void Update()
    {
          if(isBegingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
            Cursor.SetCursor(target, new Vector2(16,16), CursorMode.Auto);
        }

        if(Input.GetKeyDown("t"))
        {
            if(mainInventoryToggle != null)
            {
                mainInventoryToggle.onClick.Invoke();
            }
        }

         if(Input.GetKeyDown("q"))
        {
            if(questInventoryToggle != null)
            {
                questInventoryToggle.onClick.Invoke();
            }
        }

         if(Input.GetKeyDown("r"))
        {
            if(rawInventoryToggle != null)
            {
                rawInventoryToggle.onClick.Invoke();
            }
        }
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Selecting item "+ this.gameObject.name);
            isBegingHeld = true;
            
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
        }
    }

    private void OnMouseUp()
    {
        isBegingHeld = false;
        Cursor.SetCursor(pointer, new Vector2(16,16), CursorMode.Auto);
    }
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>{}