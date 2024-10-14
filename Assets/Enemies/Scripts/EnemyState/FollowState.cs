using UnityEngine;

public class FollowState : MonoBehaviour, IState 
{
    private EnemyController enemy;

    private FollowLogic followLogic;
    public FollowLogic FollowLogica => followLogic;

    private AttackingState attackingState;
    public FollowState (EnemyController enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {        
        Debug.Log("Entro en follow");
    }
    public void Exit()
    {
        Debug.Log("Saliste de follow");
    }
    public void UpdateState()
    {
        enemy.followLogic.FollowPlayer();        

        if (enemy.followLogic.minRange >= enemy.followLogic.distance)
        {
            enemy.StateMachine.TransitionTo(enemy.StateMachine.attackingState);
            enemy.animator.SetBool("isChasing", false);
        }
    }
}
