using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{

    public GameObject VictoryMenuUI;

    public void Update()
    {
        /*if (GameManager.nbDefDone == 5)
        {
            Victory();
        }*/

        if(Input.GetKeyDown(KeyCode.V))
        {
            Victory();
        }
    }


    void Victory()
    {
        VictoryMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.Paused = true;

    }

    public void NewGame()
    {
        SceneManager.LoadScene("ManagementPhase");
    }

    public void HighScores()
    {
        Debug.Log("Chargement des meilleurs scores");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        VictoryMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.Paused = false;
    }

}
