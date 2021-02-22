using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public Board board;

    // Start is called before the first frame update
    void Start()
    {
        board.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
