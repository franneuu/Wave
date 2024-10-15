using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public HelicopterHealth helicopterHealth;
    public float timeLimit = 120f;
    private float currentTime;
    public int enemiesKilled;
    public int enemiesSpawned;

    void Start()
    {
        currentTime = timeLimit;
    }
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            LoseGame();
        }

        CheckEnemies();
    }
    void CheckEnemies()
    {
        if (enemiesKilled == enemiesSpawned && helicopterHealth.chopperDead == true)
        {
            WinGame();
        }
    }
    public void LoseGame()
    {
        Debug.Log("¡Tiempo agotado! Has perdido.");
        // Mostrar pantalla de derrota
    }

    void WinGame()
    {
        Debug.Log("¡Has impedido que los enemigos se escapen!");        
    }
}
