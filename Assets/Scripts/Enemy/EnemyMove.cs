using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]private Transform lastCheck;

    private NavMeshAgent navMeshAgent;

    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        lastCheck = GameObject.FindWithTag("LastCheck").transform;
    }

    private void Update() {
        navMeshAgent.SetDestination(lastCheck.position);
    }
}
