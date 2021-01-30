using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDeactivate : MonoBehaviour
{
    public GameObject obj;

    void OnTriggerEnter(Collider collision)
    {
        obj = collision.gameObject;
    }

    void OnTriggerExit(Collider collision)
    {
        obj.SetActive(true);
        obj = null;
    }
}
