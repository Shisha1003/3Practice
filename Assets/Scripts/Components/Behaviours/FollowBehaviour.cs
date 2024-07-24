using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class FollowBehaviour : MonoBehaviour, IBehaviour
{

    private NavMeshAgent _navMeshAgent;
    private Transform _targetTransform;

    public float stoppingDistance = 1.0f;
    public float detectionRadius = 10.0f;
    public float followScore = 0f;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        CharacterHealth targetObject = FindAnyObjectByType<CharacterHealth>();
        GameObject targetGameObject = targetObject.gameObject;

        _targetTransform = targetGameObject.transform;
    }
    public void Behave()
    {
        if (_targetTransform != null)
        {
            _navMeshAgent.SetDestination(_targetTransform.position);

            if (Vector3.Distance(transform.position, _targetTransform.position) <= stoppingDistance)
            {
                _navMeshAgent.isStopped = true;
            }
            else
            {
                _navMeshAgent.isStopped = false;
            }
        }
    }

    public float Evaluate()
    {
        followScore = 0f;

        if (_targetTransform != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, _targetTransform.position);
            if (distanceToTarget <= detectionRadius)
            {
                return followScore = 1f; 
            }
        }
        return 0f;
    }
}
