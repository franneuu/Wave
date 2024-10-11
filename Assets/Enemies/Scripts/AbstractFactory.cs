using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFactory : MonoBehaviour
{
    [SerializeField] private BlueFactory blueFactory;
    [SerializeField] private RedFactory redFactory;

    private void Update()
    {
        
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
