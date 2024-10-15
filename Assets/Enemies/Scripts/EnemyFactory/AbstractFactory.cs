using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFactory : MonoBehaviour
{
    [SerializeField] private BlueFactory blueFactory;
    [SerializeField] private RedFactory redFactory;
     
    public int maxEnemies = 3; 
    public float spawnInterval = 3f;
    public int spawnedEnemies;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval); 
    }
    private void SpawnEnemy()
    {
        if (spawnedEnemies < maxEnemies)
        {            
            if (Random.value > 0.5f)
            {
                SpawnRed();
                spawnedEnemies++;
                GameManager.instance.levelController.enemiesSpawned++;
            }
            else
            {
                SpawnBlue();
                spawnedEnemies++;
                GameManager.instance.levelController.enemiesSpawned++;
            }
        }
        else if (spawnedEnemies > maxEnemies)
        {
            Debug.Log("No hay mas spawn");
        }
    }
    private void SpawnRed()
    {
        redFactory.CreateEnemyRed("rojo");
    }
    private void SpawnBlue()
    {
        blueFactory.CreateEnemyBlue("azul");
    }
}
