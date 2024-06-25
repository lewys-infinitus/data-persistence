using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     LoadName();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void QuitGame()
    {
        // This will quit the application when running in Unity Editor or standalone build
        // It will have no effect in the Unity Editor play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void NewNameSelected()
    {
        MainManager.Instance.playerName = name;

        SaveName();
    }

    [System.Serializable]
    class SaveData

    {
        public string playerName;
    }

    public void SaveName()
    {
        //created a new instance of the save data and filled its player name member with the playerName variable saved in the MainManager
        SaveData data = new SaveData();
        data.playerName = MainManager.Instance.playerName;

        //transformed that instance to JSON with JsonUtility.ToJson
        string json = JsonUtility.ToJson(data);

        //special method File.WriteAllText to write a string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
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

            //Finally, it will set the playerName to the name saved in that SaveData
            MainManager.Instance.playerName = data.playerName;
        }
    }

    public void SaveNameEntered()
    {
        MainManager.Instance.SaveName();
    }
}