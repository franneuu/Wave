using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{ 
    [SerializeField] private EnemyScriptable enemyAttributes;
    public int currentHealth;
    private bool flashActive;
    private SpriteRenderer enemySprite;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = enemyAttributes.maxHealth;
        enemySprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (flashActive)
        {
            if (enemyAttributes.flashCounter > enemyAttributes.flashLength * .99f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (enemyAttributes.flashCounter > enemyAttributes.flashLength * .82f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (enemyAttributes.flashCounter > enemyAttributes.flashLength * .66f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (enemyAttributes.flashCounter > enemyAttributes.flashLength * .49f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (enemyAttributes.flashCounter > enemyAttributes.flashLength * .33f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (enemyAttributes.flashCounter > enemyAttributes.flashLength * .16f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (enemyAttributes.flashCounter > 0f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                flashActive = false;
            }
            enemyAttributes.flashCounter -= Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        flashActive = true;
        enemyAttributes.flashCounter = enemyAttributes.flashLength;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Enemy died! " + currentHealth);
    }
}

