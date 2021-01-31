using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Goal : MonoBehaviour
{
    public NextGoal objective;
    private SphereCollider sphercoll;
    public string myname;
    public string hisname;
    private AddDucklingToFollow add;
    private Light pLight;
    private PlayerMovement player;
    
    void Start()
    {
        myname = name;
        objective = GameObject.Find("Objective").GetComponent<NextGoal>();
        hisname = objective.shuffledGoals.First.Value.ToString().Split(' ')[0];
        add = GameObject.FindWithTag("Player").GetComponent<AddDucklingToFollow>();
        pLight = GetComponentInChildren<Light>();
        sphercoll = this.GetComponent<SphereCollider>();
        pLight.enabled = false;
        sphercoll.enabled = false;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (objective != null)
        {
            if (objective.shuffledGoals.Count != 0)
            {
                if (name == objective.shuffledGoals.First.Value.ToString().Split(' ')[0])
                {
                    pLight.enabled = true;
                    sphercoll.enabled = true;
                }
                else
                {
                    pLight.enabled = false;
                    sphercoll.enabled = false;
                }
            }
        }
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") /* && collision.getcomponent<bush.cs>().canspawn == true*/)
        {
            player.speed = player.speed + 0.1f;
            objective.SelectNext();
            add.AddDuckling();
        }
    }
}
