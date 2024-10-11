using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyRed : Enemy
{
    [SerializeField] private string id;
    public override string Id => id;

    public float speed;
    private float distance;
    public float minRange;
    private bool isAttacking = false;

    public override void Attack()
    {       
        Debug.Log("Ataque");
    }
   
    private void Update()
    {
        FollowPlayer();
    }
    public void FollowPlayer()
    {
        if (PlayerController.instance != null)
        {            
            distance = Vector2.Distance(transform.position, PlayerController.instance.transform.position);
            Vector2 direction = PlayerController.instance.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);

            if (minRange < distance)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, PlayerController.instance.transform.position, speed * Time.deltaTime);
                //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
            else if (!isAttacking) 
            {
                isAttacking = true;
                InvokeRepeating("Attack", 1, 1);
            }           
        }
    }
}
