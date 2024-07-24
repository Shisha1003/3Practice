using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour, IBehaviour
{
    FollowBehaviour followBehaviour = new FollowBehaviour();
    private Transform _targetTransform;

    float followScore;
    public void Behave()
    {
        Debug.Log("HIT");
    }

    public float Evaluate()
    {
        followScore = 0f;
        if (Vector3.Distance(transform.position, _targetTransform.position) <= followBehaviour.stoppingDistance)
        {
            return followScore = 2f;
        }        
        return 0f;
    }

    private void Awake()
    {
        CharacterHealth targetObject = FindAnyObjectByType<CharacterHealth>();
        GameObject targetGameObject = targetObject.gameObject;

        _targetTransform = targetGameObject.transform;
    }

}
