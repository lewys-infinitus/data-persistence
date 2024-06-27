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
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    [SerializeField] private TextMeshProUGUI _bestScoreDisplay;


    // Start is called before the first frame update
    void Start()
    {
       BestScoreSetup();
    }

    public void StartGame()
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

    public void SaveNameEntered()
    {
        DataHandler.PlayerName = _inputField.text;
    }

    private void BestScoreSetup()
    {
        string name = DataHandler.LoadName();
        
        _bestScoreDisplay.text = $"Best Score: {name}";
    }
}