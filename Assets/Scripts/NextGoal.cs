using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using Random = UnityEngine.Random;

public class NextGoal : MonoBehaviour
{
    public List<Transform> Goals = new List<Transform>();
    public LinkedList<Transform> shuffledGoals = new LinkedList<Transform>();
    private int randomIndex;

    void Awake()
    {
        for (int i = 0;i < Goals.Count; i++)
        {
            Transform temp = Goals[i];
            randomIndex = Random.Range(i, Goals.Count);
            Goals[i] = Goals[randomIndex];
            Goals[randomIndex] = temp;
        }

        for (int i = 0; i < Goals.Count; i++)
        {
            shuffledGoals.AddLast(Goals[i]);
        }
    }

    void Update()
    {
        if (shuffledGoals.Count != 0)
        {
            transform.LookAt(shuffledGoals.First.Value);
            transform.RotateAround(transform.position, transform.right, 90);
            transform.RotateAround(transform.position, transform.up, 180);
            transform.rotation = Quaternion.Euler(90,transform.eulerAngles.y,0f);
        }
    }

    public void SelectNext()
    {
        Debug.Log("Removed first in LList");
        if (shuffledGoals.Count != 0)
        {
            shuffledGoals.RemoveFirst();
        }
    }

}
