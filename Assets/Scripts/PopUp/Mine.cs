using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mine : MonoBehaviour
{
    PopupMessage popupMessage;
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        popupMessage = gameController.GetComponent<PopupMessage>();
        popupMessage.Open("Mine", "This is the Mine");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        popupMessage.Open("Mine", "This is the Mine");
    }
}

