using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

public class CreationArme : MonoBehaviour
{
    string jsonString;
    string path;
    List<Armes> Armes = new List<Armes>();
    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        path = "JSON/ListeArmes.json";
        jsonString = File.ReadAllText(path);
        Armes = JsonConvert.DeserializeObject<List<Armes>>(jsonString);
        for (int i = 0; i < 5; i++)
        {
            Armes testArme = generateArme();
            Inventory.instance.addItem(testArme);
        }
        
    }

    public Armes generateArme()
    {

        /*GameObject testArme = new GameObject("testArme");
        testArme.AddComponent<Armes>();*/

        Armes testArme = new Armes();
        Debug.Log("name : " + testArme.itemName);
        testArme = Armes[rnd.Next(0, Armes.Count)];
        testArme.type = Equipment.EquipmentType.weapon;
        testArme.ArmeGO = Instantiate((GameObject)Resources.Load(testArme.itemName));
        testArme.ArmeGO.SetActive(false);



        // Armes returnedArme = armes[rnd.Next(0, armes.Count)];
        int numbreOfElementInEnum;
        switch (testArme.weapontype){
            case weaponType.contondant:
                numbreOfElementInEnum = Enum.GetNames(typeof(Gear.adjectifArmeContondante)).Length - 1;
                testArme.adjectifCont = (Gear.adjectifArmeContondante)rnd.Next(0, numbreOfElementInEnum);
                break;
            case weaponType.estoc:
                numbreOfElementInEnum = Enum.GetNames(typeof(Gear.adjectifArmeEstoc)).Length - 1;
                testArme.adjectifEst = (Gear.adjectifArmeEstoc)rnd.Next(0, numbreOfElementInEnum);
                break;
            case weaponType.tranchant:
                numbreOfElementInEnum = Enum.GetNames(typeof(Gear.adjectifArmeTranchante)).Length - 1;
                testArme.adjectifTranch = (Gear.adjectifArmeTranchante)rnd.Next(0, numbreOfElementInEnum);
                break;
            default:
                Debug.Log("ce type d'arme n'est pas gere dans la classe creationArme, dans la fct generateArme()");
                break;
        }
        testArme.icon = Resources.Load<Sprite>(testArme.iconStr);
        return testArme;
    }
}
