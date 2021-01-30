using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera cam;

    public bool useStaticBillboard;

    void Start()
    {
        cam = Camera.main;
    }
    
    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);
        transform.LookAt(targetPosition);
    }
}
