using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionMouseOverUIManagement : MonoBehaviour
{

    public bool mouseOverUI;

    private void OnMouseOver()
    {
        mouseOverUI = true;
    }

    private void OnMouseExit()
    {
        mouseOverUI = false;
    }
}
