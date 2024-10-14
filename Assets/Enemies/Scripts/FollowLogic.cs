using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowLogic : MonoBehaviour
{
    private EnemyController enemy;
    public float distance;
    public float speed;
    public float minRange;
    private bool canAttack;  
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
                canAttack = false;
                transform.position = Vector2.MoveTowards(this.transform.position, PlayerController.instance.transform.position, speed * Time.deltaTime);
            }
            else if (minRange > distance && canAttack == false)
            {
                canAttack = true;                
            }
        }
    }
}
