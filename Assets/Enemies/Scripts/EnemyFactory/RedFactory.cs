using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFactory : MonoBehaviour
{
    [SerializeField] private EnemyRed[] enemyRed;
    private Dictionary<string, EnemyRed> enemyRedDict;

    private void Awake()
    {
        enemyRedDict = new Dictionary<string, EnemyRed>();

        foreach (var enemy in enemyRed)
        {
            enemyRedDict.Add(enemy.Id, enemy);
        }        
    }
    public EnemyRed CreateEnemyRed(string id)
    {
        if (enemyRedDict.ContainsKey(id))
        {
            return Instantiate(enemyRedDict[id], transform.position, transform.rotation);
        }
        return null;
    }
}
