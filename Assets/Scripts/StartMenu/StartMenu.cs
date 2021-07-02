using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject newGamePanel;

    private AudioManager _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNewGame()
    {
        Debug.Log("New game selected");
         _audio.Play("MenuAction");

        //show new game panel (allow player to create save name)

        //save the name in save system
    }

    public void LoadGame()
    {
        Debug.Log("Load game selected");
         _audio.Play("MenuAction");

        //Open the list of save files to allow player to select and load the desired game
    }

    public void Credits()
    {
        Debug.Log("Credits selected");
        _audio.Play("MenuAction");

        //Show game credits 
    }
}
