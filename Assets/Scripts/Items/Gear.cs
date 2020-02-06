using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/item/equiment")]
public class Gear : Equipment
{
    public int hp, atk, strength, power, mana, armor, magiqueArmor, speed, dodge, critical;
    public string iconStr;
    public adjectifArmure adjectif;
}
