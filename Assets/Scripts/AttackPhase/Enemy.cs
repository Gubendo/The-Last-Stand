using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : Character
{
    private Color oldColor;
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        oldColor = this.GetComponentInChildren<Renderer>().material.color;
        this.GetComponentInChildren<Renderer>().material.color = Color.grey;

    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        this.GetComponentInChildren<Renderer>().material.color = Color.white;

    }
    void OnMouseDown()
    {
        
        foreach (GameObject act in GameObject.FindGameObjectsWithTag("Ally"))
        {
            if (act.GetComponent<Player>().isMyTurn && act.GetComponent<Player>().isWaiting)
            {
                act.GetComponent<Player>().target=this;
            }
        }
    }
}