using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFactory : MonoBehaviour
{
    [SerializeField] private EnemyBlue[] enemyBlue;
    private Dictionary<string, EnemyBlue> enemyBlueDict;

    private void Awake()
    {
        enemyBlueDict = new Dictionary<string, EnemyBlue>();

        foreach (var enemy in enemyBlue)
        {
            enemyBlueDict.Add(enemy.Id, enemy);
        }
    }
    public EnemyBlue CreateEnemyBlue(string id)
    {
        if (enemyBlueDict.ContainsKey(id))
        {
            return Instantiate(enemyBlueDict[id], transform.position, transform.rotation);
        }
        return null;
    }
}
