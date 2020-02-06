using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*la classe Armes sert a recuperer les donnee des differente armes presente dans le jeu via un fichier json*/
[CreateAssetMenu(fileName = "New item", menuName = "Inventory/item/weapon")]
public class Armes : Equipment
{
    public GameObject ArmeGO = null;
    public int atk, strength, power, critical;
    public string iconStr;
    public weaponType weapontype;

    public adjectifArmeContondante adjectifCont;
    public adjectifArmeEstoc adjectifEst;
    public adjectifArmeTranchante adjectifTranch;

    public Armes()
    {

    }

    public Armes(Armes donneeArme){
        atk = donneeArme.atk;
        strength = donneeArme.strength;
        power = donneeArme.power;
        critical = donneeArme.critical;
        itemName = donneeArme.itemName;
        type = donneeArme.type;
    }
}

public enum weaponType { tranchant, estoc, contondant }
