using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public Transform itemsParent;
    ItemSlot[] slots;
    public GameObject inventoryUI;
    public static bool isInventoryActive ;

    public Character player;
    public Text hp;
    public Text atk;
    public Text armor;
    public Text mr;
    public Text power;
    public Text crit;
    public Text spd;
    public Text dodge;
    public Text mana;
    public Text strength;


    #region singleton
    public static InventoryUI instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("more than 1 instance of inventoryUI");
            return;

        }
        instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        isInventoryActive = isActiveAndEnabled;
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += updateUI;
        player.onStatChangedCallBack += UpdateStats;
        slots = itemsParent.GetComponentsInChildren<ItemSlot>();
        updateUI();
        UpdateStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i") && !isInventoryActive)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            isInventoryActive = !isInventoryActive;
        }

        else if (Input.GetKeyDown("i") && isInventoryActive)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            isInventoryActive = !isInventoryActive;
        }
    }

    void updateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].addItem(inventory.items[i]);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
    }

    void UpdateStats()
    {
        hp.text = "Health : " + player.hp;
        armor.text = "Armor : " + player.armor;
        mr.text = "Magique Armor : " + player.mr;
        crit.text = "Critical : " + player.crit;
        dodge.text = "Dodge : " + player.dodge;
        spd.text = "Speed : " + player.spd;
        power.text = "Power : " + player.ap;
        atk.text = "Attack : " + player.atk;
        mana.text = "Mana : " + player.mp;
        strength.text = "Strength : " + player.strength;
    }
}
