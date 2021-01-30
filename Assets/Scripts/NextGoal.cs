using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class NextGoal : MonoBehaviour
{
    public List<Transform> Goals = new List<Transform>(12);
   

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(Goals[0]);
        transform.RotateAround(transform.position, transform.right, 90);
        transform.RotateAround(transform.position, transform.up, 180);
        transform.rotation = Quaternion.Euler(90,transform.eulerAngles.y,0f);
        
    }

}
