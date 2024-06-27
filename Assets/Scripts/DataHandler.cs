using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
class SaveData
{
    public string playerName;
}

public static class DataHandler
{
    public static string PlayerName;

    public static void SaveName()
    {
        //created a new instance of the save data and filled its player name member with the playerName variable saved in the MainManager
        SaveData data = new SaveData();
        data.playerName = PlayerName;

        //transformed that instance to JSON with JsonUtility.ToJson
        string json = JsonUtility.ToJson(data);

        string fileLocation = Application.persistentDataPath + "/savefile.json";

        //special method File.WriteAllText to write a string to a file
        File.WriteAllText(fileLocation, json);

        Debug.Log($"File saved to: {fileLocation}");
    }

    public static string LoadName()
    {
        //This method is a reversal of the SaveColor method
        string path = Application.persistentDataPath + "/savefile.json";
        //It uses the method File.Exists to check if a .json file exists. If it doesn’t, then nothing has been saved,
        //so no further action is needed. If the file does exist, then the method will read its content with File.ReadAllText
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            //It will then give the resulting text to JsonUtility.FromJson to transform it back into a SaveData instance
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            return data.playerName;
        }

        return "";
    }

}
