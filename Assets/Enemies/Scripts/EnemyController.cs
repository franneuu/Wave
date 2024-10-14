using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private StateMachine stateMachine;
    public StateMachine StateMachine => stateMachine;

    //private EnemyHealth enemyHealth;
    //public EnemyHealth EnemyHealth => enemyHealth;  

    public FollowLogic followLogic;

    public Animator animator;

    public bool isChasing;

    private void Awake()
    {
        stateMachine = new StateMachine(this);
        stateMachine.Initialize(stateMachine.followState);
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        stateMachine.UpdateState();
    }


}
