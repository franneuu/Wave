using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FireGun : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform firePoint;

    private ObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(CreatePoolItem, OnTakeFromPool, OnReturnToPool, OnDestroyPoolObject, true, 1000);
    }
    public void Shoot(Vector2 direction)
    {
        Bullet bullet = bulletPool.Get();
        bullet.SetDirection(direction);
        bullet.transform.position = firePoint.position;
    }
    public Bullet CreatePoolItem()
    {
        Bullet newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.gameObject.SetActive(false);
        newBullet.bulletPool = bulletPool;
        return newBullet;
    }
    private void OnTakeFromPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }
    private void OnReturnToPool(Bullet bullet)
    {
        bullet.ResetState();
        bullet.gameObject.SetActive(false);
    }
    private void OnDestroyPoolObject(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}
