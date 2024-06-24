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

public class MenuUIHandler : MonoBehaviour
{
   // public InputField nameInputField;
   // public Text HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
       // DisplayHighScore();
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

    public void EnterPlayerName()
    {
        int enterPlayerName = MainManager.Instance.EnterPlayerName;
    }

   // public void DisplayHighScore()
   // {
     //   int highScore = MainManager.Instance.HighScore;
     //   HighScoreText.text = "High Score: " + highScore;
        // Display the high score along with the player's name if available
//if (!string.IsNullOrEmpty(MainManager.Instance.PlayerName))
       // {
       //     HighScoreText.text += " by " + MainManager.Instance.PlayerName;
       // }
   // }

   // public void SubmitName()
   // {
        //string playerName = nameInputField.text; // Corrected variable name

        //if (!string.IsNullOrEmpty(playerName))
      //  {
          //  MainManager.Instance.PlayerName = playerName;
          //  DisplayHighScore();
      //  }
       // else
      //  {
          //  Debug.LogWarning("Player name is empty. Please enter a name.");
      //  }
   // }

    // public void UpdateHighScore(int newScore)
  //  {
        //if (newScore > MainManager.Instance.HighScore)
     //   {
           // MainManager.Instance.HighScore = newScore;
          //  DisplayHighScore();
       // }
   // }
}