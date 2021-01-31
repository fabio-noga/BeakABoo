using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownBush : MonoBehaviour
{
    Animator m_Animator;
    public float speed = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Animator.speed = speed;
    }
}
