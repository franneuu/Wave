using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : MonoBehaviour, IState
{
    private EnemyController enemy;
    private FollowLogic followLogic;
    public FollowLogic FollowLogica => followLogic;
    public AttackingState(EnemyController enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("Entro en attacking");
        
    }
    public void Exit()
    {
        Debug.Log("Salio de attacking");        
    }
    public void UpdateState()
    {
        enemy.followLogic.FollowPlayer();

        if (enemy.followAttributes.minRange < enemy.followLogic.distance)
        {
            enemy.StateMachine.TransitionTo(enemy.StateMachine.followState);
            enemy.animator.SetBool("isChasing", true);
        }
    }
    public void Attack()
    {
        Debug.Log("Attacking");
    }
}
