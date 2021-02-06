using System;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    public bool bothKingsAlive = true;

    public GameObject piecePrefab;

    private List<Piece> whitePieces = null;
    private List<Piece> blackPieces = null;

    private enum p { Pawn, Rook, Knight, Bishop, King, Queen };

    //The layout of the board, the original location and type of the piece. 16 in total for each side.
    private int[] pieceOrder = new int[16]
    {
        (int)p.Pawn, (int)p.Pawn,   (int)p.Pawn,   (int)p.Pawn, (int)p.Pawn,   (int)p.Pawn,  (int)p.Pawn,   (int)p.Pawn,
        (int)p.Rook, (int)p.Knight, (int)p.Bishop, (int)p.Queen, (int)p.King, (int)p.Bishop, (int)p.Knight, (int)p.Rook
    };

    private Dictionary<int, Type> pieceLibrary = new Dictionary<int, Type>()
    {
        {(int)p.Pawn, typeof(Pawn)},
        {(int)p.Rook, typeof(Rook)},
        {(int)p.Knight, typeof(Knight)},
        {(int)p.Bishop, typeof(Bishop)},
        {(int)p.King, typeof(King)},
        {(int)p.Queen, typeof(Queen)},
    };

    public void Init(Board board)
    {
        whitePieces = CreatePieces(Color.white, new Color32(255, 255, 255, 255), board);
        blackPieces = CreatePieces(Color.black, new Color32(128, 128, 128, 255), board);

        //1, 0 for white because the royalty row will be at the bottom. 6, 7 for black because the royalty row will be at the top.
        PlacePieces(1, 0, whitePieces, board);
        PlacePieces(6, 7, blackPieces, board);

        SwitchSides(Color.black);
    }

    private List<Piece> CreatePieces(Color teamColor, Color32 spriteColor, Board board)
    {
        List<Piece> newPieces = new List<Piece>();

        for (int i = 0; i < pieceOrder.Length; i++)
        {
            GameObject newPieceObject = Instantiate(piecePrefab);
            newPieceObject.transform.SetParent(transform);

            newPieceObject.transform.localScale = new Vector3(1, 1, 1);
            newPieceObject.transform.localRotation = Quaternion.identity;

            int key = pieceOrder[i];
            Type pieceType = pieceLibrary[key];

            Piece newPiece = (Piece)newPieceObject.AddComponent(pieceType);
            newPieces.Add(newPiece);

            newPiece.Setup(teamColor, spriteColor, this);
        }

        return newPieces;
    }

    private void PlacePieces(int pawnRow, int royaltyRow, List<Piece> pieces, Board board)
    {
        for (int i = 0; i < 8; i++) //loops 8 times, placing a pawn and royalty piece each time.
        {
            pieces[i].SetSpace(board.allSpaces[i, pawnRow]); 

            pieces[ i + (pieces.Count / 2)].SetSpace(board.allSpaces[i, royaltyRow]); //start from the beginning of the royalty pieces; skips the pawn pieces.
        }
    }

    private void SetInteractive(List<Piece> allPieces, bool value)
    {
        foreach (Piece piece in allPieces)
            piece.enabled = value;
    }

    public void SwitchSides(Color color)
    {
        if (!bothKingsAlive)
        {
            ResetPieces();

            bothKingsAlive = true;

            color = Color.black;
        }

        bool isBlackTurn = color == Color.white ? true : false;
        Debug.Log("is it blacks turn? " + isBlackTurn);

        SetInteractive(whitePieces, !isBlackTurn);
        SetInteractive(blackPieces, isBlackTurn);
    }

    public void ResetPieces()
    {
        foreach (Piece piece in whitePieces)
            piece.Reset();

        foreach(Piece piece in blackPieces)
            piece.Reset();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}