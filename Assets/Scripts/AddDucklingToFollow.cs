﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AddDucklingToFollow : MonoBehaviour
{
    public GameObject duckling;
    public GameObject ducklingClone;
    public GameObject nextDuckling;
    private NextGoal objective;
    public LinkedList<GameObject> maxDucklings = new LinkedList<GameObject>();
    private Manager manager;

    void Start()
    {
        objective = GameObject.Find("Objective").GetComponent<NextGoal>();
        manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
        duckling = Resources.Load<GameObject>("Duckling");
    }

    public void AddDuckling()
    {
        ducklingClone = Instantiate(duckling);
        ducklingClone.transform.position = transform.position;


        if (maxDucklings.Count == 0)
        {
            ducklingClone.GetComponentInChildren<NPCFollow>().target = transform;
            NavMeshAgent nav = ducklingClone.GetComponentInChildren<NavMeshAgent>();
            nav.SetDestination(transform.position);
            maxDucklings.AddFirst(ducklingClone);
            manager.score++;
            Debug.Log(maxDucklings.Count);
        }
        else
        {
            NavMeshAgent nav = ducklingClone.GetComponentInChildren<NavMeshAgent>();
            GameObject last = maxDucklings.Last.Value;
            ducklingClone.GetComponentInChildren<NPCFollow>().target =
                last.GetComponentInChildren<NPCFollow>().transform;
            nav.SetDestination(last.transform.position);
            maxDucklings.AddLast(ducklingClone);
            manager.score++;
            Debug.Log(maxDucklings.Count);
        }
    }

    public void RemoveDuckling()
    {
        GameObject lastDuckling;
        List<GameObject> ducklingobjs = new List<GameObject>();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Duckling"))
        {
            ducklingobjs.Add(obj);
        }
        int number = ducklingobjs.Count;
        Debug.Log(ducklingobjs[number-1]);
        lastDuckling = ducklingobjs[number-1];
        maxDucklings.RemoveLast();
        Destroy(lastDuckling);

        

    }

}

