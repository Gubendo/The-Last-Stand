using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackMonster:Enemy
{
    public void playTurn()
    {
        Debug.Log(this.name + " joue une carte face cachée");
    }


}