using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
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
    public GameObject pausePanel;

    private AudioManager _audio;
    private float pauseCounter = 1.25f;
    private bool timerSet = true;

    void Start()
    {
        Cursor.SetCursor(pointer, new Vector2(16,16), CursorMode.Auto);
        //Do not remove these onClick invokes. They "prime" the buttons so a single click opens the menus
        //mainInventoryToggle.onClick.Invoke();

        //recycleInventoryToggle.onClick.Invoke();

        //calendarMailToggle.onClick.Invoke();

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
       
        //recycling toggle
        if(Input.GetKeyDown("r"))
        {
            Debug.Log("recycling inv toggle");
            if(recycleInventoryToggle != null)
            {
                _audio.Play("MenuAction");
                recycleInventoryToggle.onClick.Invoke();
            } else
            {
                Debug.Log("Recycling toggle button is null");
            }
        }
        //inventory toggle
        if(Input.GetKeyDown("t"))
        {
            Debug.Log("inventory toggle");
            if(recycleInventoryToggle != null)
            {
                _audio.Play("MenuAction");
                mainInventoryToggle.onClick.Invoke();
            }else
            {
                Debug.Log("Inventory toggle button is null");
            }
        } 
        //mail toggle
        if(Input.GetKeyDown("m"))
        {
            Debug.Log("mail toggle");
            if(calendarMailToggle != null)
            {
                _audio.Play("MenuAction");
                calendarMailToggle.onClick.Invoke();
            } else
            {
                Debug.Log("Mail toggle button is null");
            }
        }
        //pause menu
        if (Input.GetKeyDown("p"))
        {
            _audio.Play("MenuAction");
            PanelFader fader = pausePanel.GetComponent<PanelFader>();
            fader.Fade(true);
            pauseCounter = 1.25f;
            timerSet = false;
        }

        pauseCounter -= Time.deltaTime;
        if (pauseCounter <= 0f && !timerSet)
        {
            PauseTime();
        }
    }

    private void PauseTime()
    {
        timerSet = true;
        Debug.Log("stopping time");
        Time.timeScale = 0f;
    }
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>{}