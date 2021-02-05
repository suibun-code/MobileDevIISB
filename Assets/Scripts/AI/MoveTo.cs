using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveTo : MonoBehaviour
{
    public GameObject goal;
    
    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find ("Player");
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.transform.position;
    }

}
