using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject crossHair;

    public GameObject continueButton;   // To hold the continue button
    public GameObject mainMenuButton;   // To hold the menu button
    public GameObject exitGameButton;   // To hold the exit button

    GameController gc;

    // Use this for initialization
    void Awake()
    {
        gc = GameObject.FindObjectOfType<GameController>();

        // **** Set all the listeners for each button ****
        continueButton.GetComponent<Button>().onClick.AddListener(delegate { ContinueGame(); });
        mainMenuButton.GetComponent<Button>().onClick.AddListener(delegate { MainMenu(); });
        exitGameButton.GetComponent<Button>().onClick.AddListener(delegate { ExitGame(); });
    }

    /// <summary>
    /// Continue game
    /// </summary>
    public void ContinueGame()
    {
        Time.timeScale = 1f;            // Resume game, set time back to real time
        gameObject.SetActive(false);    // set cavas to false
        Cursor.visible = false;
        crossHair.SetActive(true);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled = true;
        gc.ResumeMusic();
    }

    /// <summary>
    /// Goes back to main menu
    /// </summary>
    /// <param name="scene"> The scene variable will hold the name of the scene to be called </param>
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Exits game, closes unity
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
}