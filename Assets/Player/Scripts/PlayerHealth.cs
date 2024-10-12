using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 40;
    private bool flashActive;
    [SerializeField] private float flashLength = 0f;
    [SerializeField] private float flashCounter = 0f;
    private SpriteRenderer playerSprite;
    private void Awake()
    {
        currentHealth = maxHealth;
        playerSprite = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        flashActive = true;
        flashCounter = flashLength;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Player died!");
    }
}
