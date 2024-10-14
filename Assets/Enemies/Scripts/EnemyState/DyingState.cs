using UnityEngine;

public class DyingState : MonoBehaviour, IState
{
    private EnemyController enemy;
    public DyingState(EnemyController enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("Entro en dying");
    }
    public void Exit()
    {

    }
    public void UpdateState()
    {

    }
}
