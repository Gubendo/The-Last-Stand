using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickableBat : MonoBehaviour
{
    [SerializeField]
    private string batName;
    PopupMessage popupMessage;
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameManager");
        popupMessage = gameController.GetComponent<PopupMessage>();
        if(batName=="") batName=this.name;
    }

    private void OnMouseDown()
    {
        Debug.Log("BONJOUR" +batName);
        popupMessage.Open(batName, "This is the " +batName);
    }


}