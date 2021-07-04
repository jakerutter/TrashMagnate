using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{

    private AudioManager _audio;

    public GameObject inputField;
    public TMP_Dropdown fileDropDown;
    private string saveNameText;

    // Start is called before the first frame update
    void Start()
    {
        _audio = FindObjectOfType<AudioManager>();

        //saveNameText = input.ToString();
    }

    public void CreateNewGame()
    {
        Debug.Log("New game selected");
         _audio.Play("MenuAction");
    }

    public void LoadGame()
    {
        Debug.Log("Load game selected");
         _audio.Play("MenuAction");

        //Open the list of save files to allow player to select and load the desired game
        string[] saveFiles = SaveSystem.GetSaveFiles();

        //clear any previous options
        fileDropDown.options.Clear();

        for (int i = 0; i < saveFiles.Length; i++)
        {
            Debug.Log(saveFiles[i]);

            //remove most of path before displaying
            string saveName = saveFiles[i].Replace(Application.persistentDataPath.ToString(), "");
            saveName = saveName.Replace(".jtr", "");
            saveName = saveName.Replace("/", "");
            fileDropDown.options.Add(new TMP_Dropdown.OptionData() { text = saveName });
        }

        fileDropDown.options.
    }

    public void Credits()
    {
        Debug.Log("Credits selected");
        _audio.Play("MenuAction");

        //Show game credits 
    }

    public void StartGame()
    {
        Debug.Log("Start game selected");
        _audio.Play("MenuAction");

        //Create new save file
        CreateSaveFile();

        //Start game
        SceneManager.LoadScene(1);
    }

    public void GoBack()
    {
        Debug.Log("Go back selected");
        //display main menu, hide create game menu
    }

    private void CreateSaveFile()
    {
        //Debug.Log("Called CreateSaveFile");

        saveNameText = inputField.GetComponent<TMP_InputField>().text;

        Debug.Log(saveNameText + " is save file name");

        SaveSystem.SetSpecificPath(saveNameText);
    }
}
