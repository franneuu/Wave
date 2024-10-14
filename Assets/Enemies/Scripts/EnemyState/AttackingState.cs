using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : MonoBehaviour, IState
{
    private EnemyController enemy;
    private FollowLogic followLogic;
    public FollowLogic FollowLogica => followLogic;

    public Coroutine attackCoroutine;
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
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
    }
    public void UpdateState()
    {
        ComenzarCorrutina();
        enemy.followLogic.FollowPlayer();

        if (enemy.followLogic.minRange < enemy.followLogic.distance)
        {
            enemy.StateMachine.TransitionTo(enemy.StateMachine.followState);
            enemy.animator.SetBool("isChasing", true);
        }
    }

    public void ComenzarCorrutina()
    {
        attackCoroutine = StartCoroutine(AttackRoutine());
    }

    public IEnumerator AttackRoutine()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(1f); 
        }
    }
    public void Attack()
    {
        Debug.Log("Attacking");
    }
}
