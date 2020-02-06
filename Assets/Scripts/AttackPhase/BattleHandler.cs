using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject balise;
    [HideInInspector]
    public List<GameObject> enemies;
    [HideInInspector]
    public List<GameObject> allies;
    private Spawner spawner;
    private Vector3 balisePos;
    private static float spacing = 1.5f;
    private List<Tuple<bool, int>> turnsOrder;
    private int turnIndex;
    void Start()
    {
        spawner = GetComponent<Spawner>();
        balisePos = balise.transform.position;
        Destroy(balise);
        initBattle();
        spawnEnemies();
        StartBattlePhase();
    }

    void initBattle()
    {
        enemies = new List<GameObject>(spawner.GenerateGroup(2));
        allies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ally"));
    }

    void spawnEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            GameObject tmp = Instantiate(enemies[i]);
            tmp.transform.position = balisePos - new Vector3((enemies.Count / 2 - i) * spacing, 0, 0);
            tmp.transform.LookAt(allies[(int)(allies.Count / 2)].transform);
            enemies[i] = tmp;
        }
    }
#region turnOrder calculation
    List<Tuple<bool, int>> calculateTurnOrder()
    {
        List<Tuple<bool, int>> tmpList = new List<Tuple<bool, int>>();
        for (int i = 0; i < enemies.Count; i++)
        {
            tmpList.Add(new Tuple<bool, int>(true, i));
        }
        for (int i = 0; i < allies.Count; i++)
        {
            tmpList.Add(new Tuple<bool, int>(false, i));
        }
        List<Tuple<bool, int>> finalList = new List<Tuple<bool, int>>(tmpList);
        finalList.Sort((x, y) => compareFromTuple(x, y));

        return finalList;
    }

    int compareFromTuple(Tuple<bool, int> a, Tuple<bool, int> b)
    {
        GameObject aGO;
        GameObject bGO;
        if (a.Item1) aGO = enemies[a.Item2];
        else aGO = allies[a.Item2];
        if (b.Item1) bGO = enemies[b.Item2];
        else bGO = allies[b.Item2];

        return compareFromGameObject(aGO, bGO);
    }


    int compareFromGameObject(GameObject a, GameObject b)
    {
        Character charA = a.GetComponent<Character>();
        Character charB = b.GetComponent<Character>();
        return compareSpeed(charA, charB);
    }
    int compareSpeed(Character a, Character b)
    {
        if (a.spd == b.spd) return 0;
        if (a.spd > b.spd) return -1;
        return 1;
    }
#endregion

    void StartBattlePhase()
    {
        turnsOrder = calculateTurnOrder();
        turnIndex=0;
        PlayTurn();
    }
    void PlayTurn()
    {
        Tuple<bool,int> actTurn =turnsOrder[turnIndex]; 
        if(actTurn.Item1)
        {
            enemies[actTurn.Item2].GetComponent<AttackMonster>().playTurn();
            NextTurn();
        }
        else
        {
            allies[actTurn.Item2].GetComponent<Player>().isMyTurn=true;
        }
    }
    public void NextTurn()
    {
        turnIndex++;
        if(turnIndex>=turnsOrder.Count)
        {
            endBattlePhase();
        }
        else PlayTurn();
    }
    void endBattlePhase()
    {
        Debug.Log("FIN PHASE");
        //if pas fini TODO;
        StartBattlePhase();
    }
}
