using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelController : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshSurface nMS = GameObject.FindObjectOfType<NavMeshSurface>();
        nMS.UpdateNavMesh(nMS.navMeshData); 
    }
}
