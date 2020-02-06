
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemiesData
{
    [SerializeField]
    public List<MonstersGroup> enemiesGroup = new List<MonstersGroup>();

    private EnemiesData()
    { }
    private static EnemiesData _instance;

    public static EnemiesData GetInstance()
    {
        if (_instance == null)
        {
            _instance = new EnemiesData();  
        }
        return _instance;
    }

}