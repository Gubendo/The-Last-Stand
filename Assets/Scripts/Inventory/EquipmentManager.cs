using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region singleton
    public static EquipmentManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("more than 1 instance of EquipmentManager");
            return;

        }
        instance = this;
    }
    #endregion

    public Character character;
    public Equipment[] currentEquipment;  

    private void Start()
    {
       int numSlots = System.Enum.GetNames(typeof(Equipment.EquipmentType)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void equip(Equipment newStuff)
    {
        int index = (int)newStuff.type;
        if (currentEquipment[index] != null)
        {
            Inventory.instance.addItem(currentEquipment[index]);
        }
        currentEquipment[index] = newStuff;
        character.updateStatsEquip();
    }
}
