using JetBrains.Annotations;
using UnityEngine;


[CreateAssetMenu(fileName = "FollowScriptable", menuName = "FlyWeight/FollowAtributes", order = 0)]
public class FollowScriptable : ScriptableObject
{
    [SerializeField] public float speed;
    [SerializeField] public float minRange;
   }
