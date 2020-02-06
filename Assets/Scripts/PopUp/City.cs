using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class City : MonoBehaviour
{
    PopupMessage popupMessage;
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        popupMessage = gameController.GetComponent<PopupMessage>();
        popupMessage.Open("City", "This is the City");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        popupMessage.Open("City", "This is the City");
    }
}
