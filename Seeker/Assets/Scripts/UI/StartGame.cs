using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public Button startButton;           // To hold the play button
    public Button quitButton;           // To hold the control button

    private void Awake()
    {
        // **** Set all the listeners for each button ****
        startButton.onClick.AddListener(delegate { start(); });
        quitButton.onClick.AddListener(delegate { quit(); });
    }

    /// <summary>
    /// Start Game: Loads the first scene
    /// </summary>
    /// <param name="scene"> Start scene </param>
    public void start()
    {
        SceneManager.LoadScene("Main");
    }

    /// <summary>
    /// Exit Game
    /// </summary>
    public void quit()
    {
        Application.Quit();
    }
}
