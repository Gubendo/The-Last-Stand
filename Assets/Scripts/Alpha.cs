using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Alpha : MonoBehaviour
{
    public string sceneName;
    public GameObject canvas;
    // Start is called before the first frame update
    public void load()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(true);
        }
    }
    public void mainM()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
