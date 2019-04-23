using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public Button startButton;           // To hold the play button
    public Button quitButton;           // To hold the control button
    public Text loadText;

    private void Awake()
    {
        // **** Set all the listeners for each button ****
        Cursor.visible = true;
        startButton.onClick.AddListener(delegate { start(); });
        quitButton.onClick.AddListener(delegate { quit(); });
        loadText.text = "";
    }

    /// <summary>
    /// Start Game: Loads the first scene
    /// </summary>
    /// <param name="scene"> Start scene </param>
    public void start()
    {
        loadText.text = "Loading . . .";
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
