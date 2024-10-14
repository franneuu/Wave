using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlue : Enemy
{
    [SerializeField] private string id;
    public override string Id => id;
}
