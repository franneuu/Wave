using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlue : Enemy
{
    [SerializeField] private string id;
    public override string Id => id;

    private Chase chase;
    public override void Attack()
    {
        Debug.Log("Ataque");
    }
    private void Update()
    {
        chase.FollowPlayer();
    }
}