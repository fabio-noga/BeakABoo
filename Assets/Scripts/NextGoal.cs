using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class NextGoal : MonoBehaviour
{
    public List<Transform> Goals = new List<Transform>();
    public LinkedList<Transform> shuffledGoals = new LinkedList<Transform>();
    public List<Transform> Enemies = new List<Transform>();
    public LinkedList<Transform> shuffledEnemies = new LinkedList<Transform>();
    
    private int randomIndex;
    private int randomIndexe;
    private int randomIndexi;

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
        
        for (int i = 0;i < Enemies.Count; i++)
        {
            Transform temp = Enemies[i];
            randomIndexe = Random.Range(i, Enemies.Count);
            Enemies[i] = Enemies[randomIndexe];
            Enemies[randomIndexe] = temp;
        }
        
        for (int i = 0; i < Enemies.Count; i++)
        {
            shuffledEnemies.AddLast(Enemies[i]);
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
        else
        {
            ReAddGoals();
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
    
    public void SelectNextEnemy()
    {
        for (int i = 0;i < Enemies.Count; i++)
        {
            Transform temp = Enemies[i];
            randomIndexi = Random.Range(i, Enemies.Count);
            Enemies[i] = Enemies[randomIndexi];
            Enemies[randomIndexi] = temp;
        }
        
        for (int i = 0; i < Enemies.Count; i++)
        {
            shuffledEnemies.AddLast(Enemies[i]);
        }
        Transform temp1;
        temp1 = shuffledEnemies.First.Value;
        shuffledEnemies.RemoveFirst();
        shuffledEnemies.Last.Value = temp1;
    }

    public void ReAddGoals()
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
        Debug.Log(shuffledGoals.Count);
    }
}
