using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private AddDucklingToFollow add;
    private PlayerMovement player;
    private SphereCollider spherecoll;
    private NextGoal objective;
    public Transform selectedTarget;
    public Manager manager;
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        objective = GameObject.Find("Objective").GetComponent<NextGoal>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        add = GameObject.FindWithTag("Player").GetComponent<AddDucklingToFollow>();
    }

    void Update()
    {
        selectedTarget = objective.shuffledEnemies.First.Value;
        transform.position = selectedTarget.position;
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && add.maxDucklings.Count != 0)
        {
            objective.SelectNextEnemy();
            manager.score--;
            player.speed = player.speed - 0.1f;
            add.RemoveDuckling();
        }
    }
}
