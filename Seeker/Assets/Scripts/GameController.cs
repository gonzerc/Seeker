using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Text endGame;
    public CrowdSpawner CrowdSpawner;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        endGame.text = "";
    }

    public void setEndGameText(string text)
    {
        endGame.text = text;
    }

    public void RestartScene()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        Debug.Log("Restarting...");
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseMusic()
    {
        GetComponent<AudioSource>().Pause();
    }

    public void ResumeMusic()
    {
        GetComponent<AudioSource>().Play();
    }

}
