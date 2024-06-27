using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private Text _scoreDisplay;
    [SerializeField] private Text _bestScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        BestScoreSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    private void BestScoreSetup()
    {
        string name = DataHandler.LoadName();

        _bestScoreDisplay.text = $"Best Score: {name}";
    }
}
