using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController player;
    public EnemyController enemy;
    public PlayerHealth playerHealth;
    public LevelController levelController;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        player = FindObjectOfType<PlayerController>();
        enemy = FindObjectOfType<EnemyController>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        levelController = FindObjectOfType<LevelController>();
    }
}
