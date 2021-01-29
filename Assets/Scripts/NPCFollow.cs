using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollow : MonoBehaviour
{


    public Transform target;
    NavMeshAgent nav;
    private NavMeshAgent navMeshAgent;
    public float closeEnoughMeters = 0.4f;
    public float acceleration = 2f;
    public float deceleration = 60f;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        nav.SetDestination(target.position);
        navMeshAgent = gameObject.GetComponentInChildren<NavMeshAgent>();
        if (navMeshAgent.hasPath)
            navMeshAgent.acceleration = (navMeshAgent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;

    }
}
