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

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        nav.SetDestination(target.position);
        //Debug.Log(target.position + " " + this.transform.position);
        if (target.position.z > transform.position.z && target.position.x < transform.position.x)
        {
            //Top Left
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("Horizontal", 1);
        }
        if (target.position.z > transform.position.z && target.position.x > transform.position.x)
        {
            //Top Right
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("Horizontal", -1);
        }
        if (target.position.z < transform.position.z && target.position.x < transform.position.x)
        {
            //Down Left
            animator.SetFloat("Vertical", -1);
            animator.SetFloat("Horizontal", -1);
        }
        if (target.position.z < transform.position.z && target.position.x > transform.position.x)
        {
            //Down Right
            animator.SetFloat("Vertical", -1);
            animator.SetFloat("Horizontal", 1);
        }
        navMeshAgent = gameObject.GetComponentInChildren<NavMeshAgent>();
        if (navMeshAgent.hasPath)
            navMeshAgent.acceleration = (navMeshAgent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;

    }
}
