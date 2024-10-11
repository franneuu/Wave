using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chase : MonoBehaviour
{
    private float distance;
    public float maxRange;
    public float minRange;
    public float speed;
    public void FollowPlayer()
    {
        if (PlayerController.instance != null)
        {
             //distance = Vector2.Distance(transform.position, playerController.transform.position);
             //Vector2 direction = playerController.transform.position - transform.position;
             //direction.Normalize();
             //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

             
             
                 transform.position = Vector2.MoveTowards(this.transform.position, PlayerController.instance.transform.position, speed * Time.deltaTime);
                 //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
             
        }      
    }

   
}
