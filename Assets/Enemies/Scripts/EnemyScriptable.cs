using JetBrains.Annotations;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyScriptable", menuName = "FlyWeight/EnemyAtributes", order = 0)]
public class EnemyScriptable : ScriptableObject 
{
    [SerializeField] public int maxHealth;
    [SerializeField] public AudioClip attackSound;  
    [SerializeField] public float flashLength;
    [SerializeField] public  float flashCounter;
}

