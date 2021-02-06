using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
public Board board;
public PieceManager pieceManager;

    // Start is called before the first frame update
    void Start()
    {
        board.Init();
        pieceManager.Init(board);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
