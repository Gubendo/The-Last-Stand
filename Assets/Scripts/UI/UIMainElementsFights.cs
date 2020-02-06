using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMainElementsFights : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject txt;
    public GameObject indic;
    public int idAction;

    private void Start()
    {
        indic.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData data)
    {
        indic.SetActive(true);
    }

    public void OnPointerExit(PointerEventData data)
    {
        indic.SetActive(false);
    }
    public void OnPointerClick(PointerEventData data)
    {
        foreach (GameObject act in GameObject.FindGameObjectsWithTag("Ally"))
        {
            if (act.GetComponent<Player>().isMyTurn)
            {
                act.GetComponent<Player>().DoAction(idAction);
            }
        }
    }


}
