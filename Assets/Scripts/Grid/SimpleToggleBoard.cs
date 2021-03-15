using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleToggleBoard : MonoBehaviour
{

    public GameObject board;



    void Start() 
    {
        // board = GameObject.FindGameObjectWithTag("GameBoard");    
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
