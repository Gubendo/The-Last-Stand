using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Building : MonoBehaviour {

    Color material_color_base;
    public GameObject canvas; //c'est peutêtre pas le mieux de faire comme ça.
                               // il vaut peut etre mieux faire une recherhce de canvas dans le start
                               //parce que là on va devoir remettre le canvas pour chaque batiment ...
    public Sprite building_icon;
    [HideInInspector]
    public bool onMouseOver;
    public GameObject detectionZoneMouseOverUI;
    GameObject eventSys;
    virtual protected void OnClick() { }

    void OnMouseDown()
    {
        OnClick();
    }
    void Start()
    {
        if(GetComponent<MeshRenderer>() != null)
        {
            material_color_base = GetComponent<MeshRenderer>().material.color;
        }
        else
        {

        }
    }

    private void OnMouseOver()
    {
        if (GetComponent<MeshRenderer>() != null)
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;

        }
        onMouseOver = true;
    }

    private void OnMouseExit()
    {
        if (GetComponent<MeshRenderer>() != null)
        {
            GetComponent<MeshRenderer>().material.color = material_color_base;
        }
        onMouseOver = false;
    }

    private void Update()
    {
        //Debug.Log(EventSystem.current.IsPointerOverGameObject());
        if (Input.GetMouseButtonDown(0) && !onMouseOver && !EventSystem.current.IsPointerOverGameObject())
        {
            canvas.SetActive(false);
        }
    }
}
