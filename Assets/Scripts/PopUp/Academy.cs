using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Academy : MonoBehaviour
{
    PopupMessage popupMessage;
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        popupMessage = gameController.GetComponent<PopupMessage>();
        popupMessage.Open("Academy", "This is the Academy");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnMouseDown()
    {
        popupMessage.Open("Academy", "This is the Academy");
    }
}
