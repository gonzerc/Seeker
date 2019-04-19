using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    // Pause Menu canvas declorated variables
    public GameObject puaseCanvas;
    public Button continueButton;
    public Button mainMenuButton;
    public Button quitGameButton;

    // Use this for initialization
    void Awake()
    {
        // **** Set all the listeners for each button ****
        continueButton.onClick.AddListener(delegate { ContinueGame(); });
        mainMenuButton.onClick.AddListener(delegate { MainMenu("MainMenu"); });
        quitGameButton.onClick.AddListener(delegate { exit(); });
    }

    /// <summary>
    /// Continue game
    /// </summary>
    public void ContinueGame()
    {
        Time.timeScale = 1f;            // Resume game, set time back to real time
        puaseCanvas.SetActive(false);   // set cavas to false
    }

    /// <summary>
    /// Goes back to main menu
    /// </summary>
    /// <param name="scene"> The scene variable will hold the name of the scene to be called </param>
    public void MainMenu(string scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Exits game, closes unity
    /// </summary>
    public void exit()
    {
        Application.Quit();
    }
}
