using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;
public class Spawner : MonoBehaviour
{
    public IntGameObjectDictionary prefabMonsters;

    private void Awake()
    {
        EnemiesData.GetInstance().enemiesGroup = JsonConvert.DeserializeObject<List<MonstersGroup>>(File.ReadAllText("./JSON/monsters.json"));
    }

    public List<GameObject> GenerateGroup(int difficulty)
    {
        List<GameObject> spawnedMonsters = new List<GameObject>();
        System.Random rnd = new System.Random();
        MonstersGroup myGroup;
        do
        {
            int act = rnd.Next(0, EnemiesData.GetInstance().enemiesGroup.Count - 1);
            myGroup = EnemiesData.GetInstance().enemiesGroup[act];
        } while (myGroup.difficulty!=difficulty);

        for (int i = 0; i < myGroup.amount; i++)
        {
            GameObject actGO = prefabMonsters.dictionary[myGroup.ids[i]];
            spawnedMonsters.Add(actGO);
        }
        return spawnedMonsters;
    }
}