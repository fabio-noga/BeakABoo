using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Camera target;
    void Start()
    {
        target = Camera.main;
    }
    void Update()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition);
    }
}
