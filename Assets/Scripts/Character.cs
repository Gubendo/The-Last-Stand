
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Character : MonoBehaviour
{
    #region Basic stats
    [SerializeField]
    public string charName;
    [SerializeField]
    public int hp;
    [SerializeField]
    public int mp;
    [SerializeField]
    public int atk;
    [SerializeField]
    public int ap;
    [SerializeField]
    public int spd;
    [SerializeField]
    public int dodge;
    [SerializeField]
    public int crit;
    [SerializeField]
    public int strength;
    [SerializeField]
    public int armor;

    [SerializeField]
    public int mr;

    [SerializeField]
    public List<atkType> weaknesses;
    [SerializeField]
    public List<atkType> resistances;
    #endregion

    #region actual stats
    public int actHP;
    public int actArmor;
    public int actMR;
    #endregion

    public delegate void OnStatChanged();
    public OnStatChanged onStatChangedCallBack;

    private void Start() {
        actHP=hp;
        actArmor=armor;
        actMR=mr;
    }

    public void updateStatsEquip()
    {
        hp = 0;
        mp = 0;
        atk = 0;
        ap = 0;
        spd = 0;
        dodge = 0;
        crit = 0;
        strength = 0;
        armor = 0;
        mr = 0;

        foreach (Equipment item in EquipmentManager.instance.currentEquipment)
        {
            if (item is Gear)
            {
                hp += ((Gear) item).hp;
                mp += ((Gear)item).mana;
                atk += ((Gear)item).atk;
                ap += ((Gear)item).power;
                spd += ((Gear)item).speed;
                dodge += ((Gear)item).dodge;
                crit += ((Gear)item).critical;
                strength += ((Gear)item).strength;
                armor += ((Gear)item).armor;
                mr += ((Gear)item).magiqueArmor;
            }
            if (item is Armes)
            {
                atk += ((Armes)item).atk;
                strength += ((Armes)item).strength;
                crit += ((Armes)item).critical;
                ap += ((Armes)item).power;
            }
        }
        onStatChangedCallBack.Invoke();
    }

    /**
        Return a vector 3 , x = damage dealt to hp , y = damage dealt to mr , z = damage dealt to armor
        in case of vampirism etc,
    **/
    public Vector3 TakeDamage(int amount, atkType type)
    {
        Vector3 result = Vector3.zero;
        int realDamage = amount;
        if (weaknesses.Contains(type)) realDamage = (int)(realDamage * 1.5);
        else if (resistances.Contains(type)) realDamage = (int)(realDamage * 0.5);
        if(type==atkType.BRUT)
        {
            //NONE
            actHP-=realDamage;
            result.x = realDamage;
        }
        else if (type < atkType.SEPARATION)
        {
            // MAGIC DMG
            
            actMR-=realDamage;
            if(actMR<=0)
            {
                result.y=realDamage+actMR;
                realDamage = -actMR;
                actMR=0;
                actHP-=realDamage;
                result.x = realDamage;
            }
        }
        else
        {
            // PHYSICAL DMG
            
            actArmor-=realDamage;
            if(actArmor<=0)
            {
                result.z=realDamage+actArmor;
                realDamage = -actArmor;
                actArmor=0;
                actHP-=realDamage;
                result.x = realDamage;
            }
        }
        return result;


    }
}