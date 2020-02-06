using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{

    public GameObject gameMainMenu;
    public GameObject gameOptionMenu;
    public GameObject gameCreditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        // Hide all menus
        gameOptionMenu.SetActive(false);
        gameCreditsMenu.SetActive(false);

        // Ensure that the main menu is displayed
        gameMainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCreditClicked()
    {
        // Hide main menu
        gameMainMenu.SetActive(false);

        // Display Credits
        gameCreditsMenu.SetActive(true);

    }
    public void OnOptionsClicked()
    {
        // Hide main menu
        gameMainMenu.SetActive(false);

        // Display Options
        gameOptionMenu.SetActive(true);
    }

    public void OnBackClicked()
    {
        // Hide other menus        
        gameOptionMenu.SetActive(false);
        gameCreditsMenu.SetActive(false);

        // Display Main Menu
        gameMainMenu.SetActive(true);

    }

    public void OnStartGameClicked()
    {
        // Launch the game scene.
        SceneManager.LoadScene("ManagementPhase");
    }

}
