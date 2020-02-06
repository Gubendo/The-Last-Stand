using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Farm : MonoBehaviour
{
    PopupMessage popupMessage;
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        popupMessage = gameController.GetComponent<PopupMessage>();
        popupMessage.Open("Farm", "This is the Farm");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        popupMessage.Open("Farm", "This is the Farm");
    }
}
