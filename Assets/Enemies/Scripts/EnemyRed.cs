using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyRed : Enemy
{
    [SerializeField] private string id;
    public override string Id => id;
    public override void Attack()
    {       
        Debug.Log("Ataque");
    }  
}
