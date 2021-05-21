using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

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
    public Button recycleInventoryToggle;

    private GameObject selectedObject;
    private float startPosX;
    private float startPosY;
    private AudioManager _audio;
    //private bool isBegingHeld = false;

    void Start()
    {
        Cursor.SetCursor(pointer, new Vector2(16,16), CursorMode.Auto);
        //Do not remove these onClick invokes. They "prime" the buttons so a single click opens the menus
        mainInventoryToggle.onClick.Invoke();
        questInventoryToggle.onClick.Invoke();
        rawInventoryToggle.onClick.Invoke();
        recycleInventoryToggle.onClick.Invoke();

        _audio = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        //   if(isBegingHeld)
        // {
        //     Vector3 mousePos;
        //     mousePos = Input.mousePosition;
        //     mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //     this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        //     Cursor.SetCursor(target, new Vector2(16,16), CursorMode.Auto);
        // }

        if(Input.GetKeyDown("t"))
        {
            if(mainInventoryToggle != null)
            {
                _audio.Play("MenuAction");
                mainInventoryToggle.onClick.Invoke();
            }
        }

         if(Input.GetKeyDown("q"))
        {
            if(questInventoryToggle != null)
            {
                _audio.Play("MenuAction");
                questInventoryToggle.onClick.Invoke();
            }
        }

         if(Input.GetKeyDown("r"))
        {
            if(rawInventoryToggle != null)
            {
                _audio.Play("MenuAction");
                rawInventoryToggle.onClick.Invoke();
            }
        }
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Debug.Log("Selecting item "+ this.gameObject.name);

            if (EventSystem.current.IsPointerOverGameObject())
            {
              Debug.Log("Clicked on a panel. Ignore game objects in the background");
              return;
            }
            else{
                //clicked directly on game object. 
            }
        //     isBegingHeld = true;
            
        //     Vector3 mousePos;
        //     mousePos = Input.mousePosition;
        //     mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //     startPosX = mousePos.x - this.transform.localPosition.x;
        //     startPosY = mousePos.y - this.transform.localPosition.y;
        }
    }

    private void OnMouseUp()
    {
        // isBegingHeld = false;
        // Cursor.SetCursor(pointer, new Vector2(16,16), CursorMode.Auto);
    }
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>{}