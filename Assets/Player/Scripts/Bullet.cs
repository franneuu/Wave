using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public int shootSpeed ;
    public ObjectPool<Bullet> bulletPool;
    public PlayerController playerController;
    private Vector2 direction;

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
}
