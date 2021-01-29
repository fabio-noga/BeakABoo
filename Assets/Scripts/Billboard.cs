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
        if (!useStaticBillboard)
        {
            transform.LookAt(cam.transform);
        }

        else
        {
            transform.rotation = cam.transform.rotation;
        }

        transform.rotation = Quaternion.Euler(-20, transform.rotation.eulerAngles.y, 0f);
    }
}
