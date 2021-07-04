using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public Button previous;
    public Button next;
    public Button select;
    public GameObject currentCharacter;
    public Texture2D currentTexture;
    public GameObject currentSelectionText;

    [SerializeField] private List<Texture2D> textureList;
    [SerializeField] private List<Material> materialList;
    AudioManager _audio;
    private int currentSelection = 1;
    private Transform playerTransform;

    private void Start()
    {
        string message = "Character " + currentSelection + " of 55";
        currentSelectionText.GetComponent<TextMeshProUGUI>().SetText(message);      
        _audio = FindObjectOfType<AudioManager>();
        _audio.Play("LightGuitar");
        GameObject player = GameObject.FindGameObjectWithTag("Skin");

        if(player == null)
        {
            Debug.Log("player is null");
        }

        playerTransform = player.transform;

    }

    public void SelectCharacter()
    {
        Debug.Log("Selected character");
        _audio.Play("LevelUp");
        RecyclingInventory.SetPlayerSkin(currentTexture);
        SceneManager.LoadScene(2);  
        
    }

    public void PreviousCharacter()
    {
        Debug.Log("Show previous character");
         _audio.Play("MenuActionSmall");

        currentSelection -= 1;

        if(currentSelection < 1)
        {
            currentSelection = 55;
        }

        string message = "Character " + currentSelection + " of 55";
        currentSelectionText.GetComponent<TextMeshProUGUI>().SetText(message);

        //set current texture
        int index;
        index = currentSelection + 24;
        if(index > 55)
        {
            index -= 55;   
        }

        currentTexture = textureList[index];
        SkinnedMeshRenderer renderer = currentCharacter.GetComponent<SkinnedMeshRenderer>();
        renderer.materials[0].mainTexture = currentTexture;
    }

    public void NextCharacter()
    {
        Debug.Log("Show next character");
        _audio.Play("MenuActionSmall");

        currentSelection += 1;

        if(currentSelection > 55)
        {
            currentSelection = 1;
        }

        string message = "Character " + currentSelection + " of 55";
        currentSelectionText.GetComponent<TextMeshProUGUI>().SetText(message);

        //set current texture
        int index;
        index = currentSelection + 24;
        if(index > 54)
        {
            index -= 54;   
        }

        currentTexture = textureList[index];

        SkinnedMeshRenderer renderer = currentCharacter.GetComponent<SkinnedMeshRenderer>();
        //Material[] mats = renderer.materials;

        //mats[0].mainTexture = currentTexture;
        renderer.materials[0].mainTexture = currentTexture;
        //renderer.materials = mats;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotate left");
            playerTransform.Rotate(Vector3.down * Time.deltaTime * 100f);
            //Quaternion rotation = playerTransform.rotation;
            //rotation.y += Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            //playerTransform.rotation = rotation;
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotate right");
            playerTransform.Rotate(Vector3.up * Time.deltaTime * 100f);
            //Quaternion rotation = playerTransform.rotation;
            //rotation.y += Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            //playerTransform.rotation = rotation;
        }        
    }
}
