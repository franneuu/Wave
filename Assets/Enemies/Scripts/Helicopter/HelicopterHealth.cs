using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    private bool flashActive;
    [SerializeField] public float flashLength;
    [SerializeField] public float flashCounter;
    private SpriteRenderer choperSprite;
    void Awake()
    {
        currentHealth = maxHealth;
        choperSprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                choperSprite.color = new Color(choperSprite.color.r, choperSprite.color.g, choperSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                choperSprite.color = new Color(choperSprite.color.r, choperSprite.color.g, choperSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                choperSprite.color = new Color(choperSprite.color.r, choperSprite.color.g, choperSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                choperSprite.color = new Color(choperSprite.color.r, choperSprite.color.g, choperSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                choperSprite.color = new Color(choperSprite.color.r, choperSprite.color.g, choperSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                choperSprite.color = new Color(choperSprite.color.r, choperSprite.color.g, choperSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                choperSprite.color = new Color(choperSprite.color.r, choperSprite.color.g, choperSprite.color.b, 0f);
            }
            else
            {
                choperSprite.color = new Color(choperSprite.color.r, choperSprite.color.g, choperSprite.color.b, 1f);
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
        Debug.Log("Ganaste");
    }
}
