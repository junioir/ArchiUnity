using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.AI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform  _TargetPosition;  
    

    void Update()
    {
        _agent.SetDestination(_TargetPosition.position);

    }
}
