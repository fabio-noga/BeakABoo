using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public NextGoal objective;
    private SphereCollider sphercoll;
    public string myname;
    public string hisname;
    private AddDucklingToFollow add;
    
    void Start()
    {
        myname = name;
        objective = GameObject.Find("Objective").GetComponent<NextGoal>();
        hisname = objective.shuffledGoals.First.Value.ToString().Split(' ')[0];
        add = GameObject.FindWithTag("Player").GetComponent<AddDucklingToFollow>();
        sphercoll = this.GetComponent<SphereCollider>();
        sphercoll.enabled = false;
    }
    void Update()
    {
        if (objective != null)
        {
            if (objective.shuffledGoals.Count != 0)
            {
                if (name == objective.shuffledGoals.First.Value.ToString().Split(' ')[0])
                {
                    sphercoll.enabled = true;
                }
                else
                {
                    sphercoll.enabled = false;
                }
            }
        }
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") /* && collision.getcomponent<bush.cs>().canspawn == true*/)
        {
            objective.SelectNext();
            add.AddDuckling();
        }
    }
}
