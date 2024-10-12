using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFollowBehavior 
{
    void Follow(Transform enemyTransform, Transform playerTransform);
    void Rotate(Transform enemyTransform, Transform playerTransform);
}
