using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum playerStates
{
    WAITING,
    SKILL,
    SKILL_TARGET,
    ATTACKING,
    DEFENDING
}
public class Player : Character
{
    public bool isMyTurn = false;
    private BattleHandler battleHandler;
    public Enemy target;
    public bool isWaiting=false;
    private playerStates state=playerStates.WAITING;

    private void Awake()
    {
        battleHandler = GameObject.Find("FightManager").GetComponent<BattleHandler>();
        target=null;
    }
    public void DoAction(int idAction)
    {
        switch (idAction)
        {
            case 0:
                state=playerStates.ATTACKING;
                Debug.Log("ATTTAK");
                isWaiting=true;
                return;
            case 1:
                Debug.Log("Je fais une competence !!");
                state=playerStates.SKILL;
                isWaiting=true;
                return;
            case 2:
                Debug.Log("Je me defends !!");
                Defend();
                break;
            case 3:
                Debug.Log("J'attends!");
                break;

        }
        battleHandler.NextTurn();
    }
    private void Update()
    {
        if(state==playerStates.ATTACKING)
        {
            Attack();
        }
        else if(state==playerStates.SKILL)
        {
            state=playerStates.SKILL_TARGET;
        }
        else if(state==playerStates.SKILL_TARGET)
        {
            Skill();
        }
    }
    public void Attack()
    {
        if(Object.ReferenceEquals(target,null)) return;
        Debug.Log("J'attaque : " + target.charName);
        Debug.Log(target.TakeDamage(this.atk,atkType.TRANCHANT));
        isWaiting=false;
        isMyTurn=false;
        target=null;
        state=playerStates.WAITING;
        battleHandler.NextTurn();
    }


    public void Defend()
    {
        this.actArmor+=(int) 0.4*armor;
    }
    public void ChoseSkill()
    {

    }

    public void Skill()
    {
        if(Object.ReferenceEquals(target,null)) return;
        Debug.Log("J'attaque : " + target.charName);
        Debug.Log(target.TakeDamage(this.ap,atkType.GLACE));
        isWaiting=false;
        isMyTurn=false;
        target=null;
        state=playerStates.WAITING;
        battleHandler.NextTurn();
    }

}
