using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static string specificPath;
    public static string entirePath;

    public static void SaveGame(DataManager manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        //use specificPath in path to get the save file created by the player
        string path = GetEntirePath();

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(manager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadGame()
    {
        string path = GetEntirePath();
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

    public static string[] GetSaveFiles()
    {
        string[] filePaths = Directory.GetFiles(Application.persistentDataPath, "*.jtr");

        return filePaths;
    }

    public static string GetEntirePath()
    {
        return Application.persistentDataPath + "/" + specificPath + ".jtr";
    }
}
