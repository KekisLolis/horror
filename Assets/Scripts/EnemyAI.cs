using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform playerTransform;
    public NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent == null)
        {
            Debug.LogError("NavMeshAgent не найден на объекте.");
        }
    }
    
    void Update()
    {
        agent.destination = playerTransform.position;
    }
}