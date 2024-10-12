using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public int shootSpeed ;
    public ObjectPool<Bullet> bulletPool;
    public PlayerController playerController;
    private Vector2 direction;
    public int shootDamage;

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * shootSpeed);
    }
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }
    public void ResetState()
    {
        direction = Vector2.zero; 
    }
    private void OnEnable()
    {
        Invoke("Deactivate", 3);
    }
    private void Deactivate()
    {
        bulletPool.Release(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (collision.gameObject.tag == "Enemy")
        {
            if (enemy != null)
            {
                enemy.TakeDamage(shootDamage);
            }
        }
        bulletPool.Release(this);
    }    
}
