using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

public class CreationArmure : MonoBehaviour
{
    string jsonString;
    string path;
    List<Gear> gears = new List<Gear>();
    System.Random rnd;

    void Start()
    {
        rnd = new System.Random();
        path = "JSON/ListeArmures.json";
        jsonString = File.ReadAllText(path);
        gears = JsonConvert.DeserializeObject<List<Gear>>(jsonString);


        for (int i = 0; i < 5; i++)
        {
            Gear testGear = generateGear();
            Inventory.instance.addItem(testGear);
        }
        // Debug.Log(testGear.gearName);
        // Debug.Log(testGear.adjectif);
    }

    public Gear generateGear()
    {
        Gear returnedGear = gears[rnd.Next(0, gears.Count)];
        int numbreOfElementInEnum = Enum.GetNames(typeof(Gear.adjectifArmure)).Length - 1;
        returnedGear.adjectif = (Gear.adjectifArmure)rnd.Next(0, numbreOfElementInEnum);
        returnedGear.icon = Resources.Load<Sprite>(returnedGear.iconStr);
        return returnedGear;
    }
    
}


