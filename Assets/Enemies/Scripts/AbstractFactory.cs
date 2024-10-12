using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFactory : MonoBehaviour
{
    [SerializeField] private BlueFactory blueFactory;
    [SerializeField] private RedFactory redFactory;
     
    public int maxEnemies = 3; 
    public float spawnInterval = 3f;
    public int activeEnemies;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval); 
    }

    private void Update()
    {
        
    }
    private void SpawnEnemy()
    {
        if (activeEnemies < maxEnemies)
        {            
            if (Random.value > 0.5f)
            {
                SpawnRed();
                activeEnemies++;
            }
            else
            {
                SpawnBlue();
                activeEnemies++;
            }
        }
        else if (activeEnemies > maxEnemies)
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
