using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{

    public GameObject DefeatMenuUI;

    public void Update()
    {
        /*if (CityManager.health == 0)
        {
            Defeat();
        }*/
        if (Input.GetKeyDown(KeyCode.D))
        {
            Defeat();
        }
    }


    void Defeat()
    {
        DefeatMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.Paused = true;

    }

    public void NewGame()
    {
        SceneManager.LoadScene("ManagementPhase");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        DefeatMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.Paused = false;
    }

    public void HighScores()
    {
        Debug.Log("Chargement des meilleurs scores");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
