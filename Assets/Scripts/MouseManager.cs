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
    public Button recycleInventoryToggle;
    public Button calendarMailToggle;

    private GameObject selectedObject;
    private float startPosX;
    private float startPosY;
    private AudioManager _audio;
    private bool _showInventory = false;

    void Start()
    {
        Cursor.SetCursor(pointer, new Vector2(16,16), CursorMode.Auto);
        //Do not remove these onClick invokes. They "prime" the buttons so a single click opens the menus
        mainInventoryToggle.onClick.Invoke();

        recycleInventoryToggle.onClick.Invoke();

        calendarMailToggle.onClick.Invoke();

        _audio = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        //TODO -- this bit isnt working is throwing an error. it is intended to prevent UI clickthrough
        // if(Input.GetMouseButtonDown(0))
        // {
        //     if(EventSystem.current.IsPointerOverGameObject())
        //     {
        //         //prevent clicking through UI and ignoring it by returning
        //         return;
        //     }
        // }
        //END TODO
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(gameObject.name);
        }

        if(Input.GetKeyDown("r"))
        {
            if(recycleInventoryToggle != null)
            {
                _audio.Play("MenuAction");
                recycleInventoryToggle.onClick.Invoke();
            }
        }
         if(Input.GetKeyDown("c"))
        {
            if(calendarMailToggle != null)
            {
                _audio.Play("MenuAction");
                calendarMailToggle.onClick.Invoke();
            }
        }
    }
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>{}