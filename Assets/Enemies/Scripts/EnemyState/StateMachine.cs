using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState currentState;
    public IState CurrentState => currentState;

    public FollowState followState;
    public AttackingState attackingState;
    public DyingState dyingState;

    public StateMachine(EnemyController enemy)
    {
        this.followState = new FollowState(enemy);
        this.attackingState = new AttackingState(enemy);
        this.dyingState = new DyingState(enemy);
    }

    public void Initialize(IState state)
    {
        currentState = state;
        state.Enter();
    }
    public void TransitionTo(IState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
    public void UpdateState()
    {
        currentState.UpdateState();
    }
}