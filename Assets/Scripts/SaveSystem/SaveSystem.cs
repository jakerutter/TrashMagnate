using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static string specificPath;

    public static void SaveGame(DataManager manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        //use specificPath in path to get the save file created by the player
        //string path = Application.persistentDataPath + specificPath;
        string path = Application.persistentDataPath + "/saveGame.jtr";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(manager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadGame()
    {
        string path = Application.persistentDataPath + "/saveGame.jtr";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            return data;
        }
        else
        {
          Debug.LogError("Save file not found in " + path);
          return null;
        }
    }

    public static void SetSpecificPath(string path)
    {
        //this function is called when a player creates a new save
        specificPath = path;
    }
}
