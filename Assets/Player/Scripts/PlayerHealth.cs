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
    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }

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
