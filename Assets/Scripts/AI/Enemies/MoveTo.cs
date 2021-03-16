using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveTo : MonoBehaviour
{
    public GameObject goal;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find ("Player");
        agent.destination = goal.transform.position;
    }

    public IEnumerator Freeze(float secondsToFreeze)
    {
        Debug.Log("FREEZEEEEEEEE");

        float speed = agent.speed;

        agent.speed = 0;

        yield return new WaitForSeconds(secondsToFreeze);
        
        if (agent != null)
        {
            agent.speed = speed;
            
        }
    }
}
