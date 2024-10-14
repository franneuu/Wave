using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private StateMachine stateMachine;
    public StateMachine StateMachine => stateMachine;
    [SerializeField] public FollowScriptable followAttributes;
    [SerializeField] private int damage;
    public bool isAttacking;
    public float attackCoolDown = 1f;
    private float currentTimeAttack;

    public FollowLogic followLogic;

    public Animator animator;

    private void Awake()
    {
        stateMachine = new StateMachine(this);
        stateMachine.Initialize(stateMachine.followState);
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        stateMachine.UpdateState();
        if (isAttacking)
        {
            currentTimeAttack += Time.deltaTime;
            if (currentTimeAttack > attackCoolDown)
            {
                AttackPlayer();
                currentTimeAttack = 0f;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isAttacking = true;
            currentTimeAttack = 0;
        }
    }    
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            isAttacking = false;
            currentTimeAttack = 0f;  
        }
    }
    public void AttackPlayer()
    {
        GameManager.instance.playerHealth.TakeDamage(damage);        
    }



}
