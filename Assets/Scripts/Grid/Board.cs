using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SpaceState //the states that any one space can be in.
{
    None, Friendly, Enemy, Free, OutOfBounds
}

public class Board : MonoBehaviour
{
    public GameObject spacePrefab;
    public Space[,] allSpaces = new Space[8, 8];

    public void Init()
    {
        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
            {
                GameObject newSpace = Instantiate(spacePrefab, transform);

                RectTransform rectTransform = newSpace.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector3((j * 100) + 50, (i * 100) + 50);

                allSpaces[j, i] = newSpace.GetComponent<Space>();
                allSpaces[j, i].Setup(new Vector2Int(j, i), this);
            }

        for (int i = 0; i < 8; i += 2)
            for (int j = 0; j < 8; j++)
            {
                int offset = (j % 2 != 0) ? 0 : 1;
                int finalX = i + offset;

                allSpaces[finalX, j].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
    }

    public SpaceState ValidateSpace(int targetX, int targetY, Piece piece)
    {
        if (targetX < 0 || targetX > 7 || targetY < 0 || targetY > 7) //if the space is out of bounds, do not check if the piece can go there since it will throw and index out of bounds error.
            return SpaceState.OutOfBounds;

        Space targetSpace = allSpaces[targetX, targetY];

        if (targetSpace.currentPiece != null) //bulletproofing.
        {
            //if the colors are the same the piece at that space is friendly.
            if (piece.color == targetSpace.currentPiece.color)
                return SpaceState.Friendly;

            //if the colors are different the piece at that space is an enemy.
            if (piece.color != targetSpace.currentPiece.color)
                return SpaceState.Enemy;
        }

        return SpaceState.Free; //if everything is passed, that space is simply free.
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