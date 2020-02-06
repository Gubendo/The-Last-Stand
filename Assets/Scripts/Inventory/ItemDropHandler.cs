using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public Equipment.EquipmentType typeAllowed;
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform equipmentSlot = transform as RectTransform;
        if (RectTransformUtility.RectangleContainsScreenPoint(equipmentSlot, Input.mousePosition))
        {
            GameObject item = eventData.pointerDrag;
            if (item.GetComponent<ItemSlot>().getItem() is Equipment)
            {
                Equipment stuff = (Equipment)item.GetComponent<ItemSlot>().getItem();
                if (stuff.type == typeAllowed)
                {
                    stuff.use();
                    //remplacer la ligne suivante par une modification de l'equipement du joueur avec une update de l'UI
                    GetComponent<Image>().sprite = stuff.icon;
                    Debug.Log("equipement equipe");
                }
            }
        }

    }
}


