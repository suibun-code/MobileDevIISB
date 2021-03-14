using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleToggleBoard : MonoBehaviour
{

    GameObject board;

    public GameObject SniperTowerRef;


    void Start() 
    {
        board = GameObject.FindGameObjectWithTag("Board");    
    }

    public void Toggle()
    {
        if (board.activeInHierarchy)
        { 
            board.SetActive(false);
        }
        else
        {
            board.SetActive(true);
        }

    }
}
