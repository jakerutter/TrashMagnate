using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{

    private AudioManager _audio;

    public GameObject inputField;
    public TMP_Dropdown fileDropDown;
    private string saveNameText;
    private string selectedLoadFile;

    // Start is called before the first frame update
    void Start()
    {
        _audio = FindObjectOfType<AudioManager>();

        //saveNameText = input.ToString();
    }

    public void CreateNewGame()
    {
        //Debug.Log("New game selected");
         _audio.Play("MenuAction");
    }

    public void LoadGameMenu()
    {
        //Debug.Log("Load game selected");
         _audio.Play("MenuAction");

        //Open the list of save files to allow player to select and load the desired game
        string[] saveFiles = SaveSystem.GetSaveFiles();

        //clear any previous options
        fileDropDown.options.Clear();

        for (int i = 0; i < saveFiles.Length; i++)
        {
            //Debug.Log(saveFiles[i]);

            //remove most of path before displaying
            string saveName = saveFiles[i].Replace(Application.persistentDataPath.ToString(), "");
            saveName = saveName.Replace(".jtr", "");
            saveName = saveName.Replace("/", "");
            fileDropDown.options.Add(new TMP_Dropdown.OptionData() { text = saveName });
        }

        fileDropDown.onValueChanged.AddListener(delegate
       {
           DropDownItemSelected(fileDropDown);
       });
    }

    public void DropDownItemSelected(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;
        string saveName = dropdown.options[index].text;
        Debug.Log(saveName + " selected");

        //selectedLoadFile = Application.persistentDataPath + "/" + saveName + ".jtr";
        selectedLoadFile = saveName;
    }

    public void Credits()
    {
        Debug.Log("Credits selected");
        _audio.Play("MenuAction");

        //Show game credits 
    }

    public void StartNewGame()
    {
        //Debug.Log("Start game selected");
        _audio.Play("MenuAction");

        //Create new save file
        CreateSaveFile();

        //Start game
        SceneManager.LoadScene(1);
    }

    public void GoBack()
    {
        //Debug.Log("Go back selected");
        //display main menu, hide create game menu
    }

    private void CreateSaveFile()
    {
        //Debug.Log("Called CreateSaveFile");

        saveNameText = inputField.GetComponent<TMP_InputField>().text;

        Debug.Log(saveNameText + " is save file name");

        SaveSystem.SetSpecificPath(saveNameText);
    }

    public void LoadSelectedSave()
    {
        Debug.Log("loading game save " + selectedLoadFile);

        //set is loading game to true
        SaveSystem.SetIsLoadingGame(true);

        //put the selected save name in save system
        SaveSystem.SetSpecificPath(selectedLoadFile);
        //load start scene
        SceneManager.LoadScene(2);
    }
}
