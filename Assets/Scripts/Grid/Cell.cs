using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public TowerManager3 towerManager;

    public SpriteRenderer spriteRenderer;
    public Tower currentTower = null;
    public Vector2Int gridPosition = Vector2Int.zero;
    public Board board = null;
    public RectTransform rectTransform = null;


    public void Setup(Vector2Int newGridPosition, Board newBoard)
    {
        gridPosition = newGridPosition;
        board = newBoard;

        rectTransform = GetComponent<RectTransform>();
    }

    public void OnMouseDown()
    {
        towerManager.CreateTower(this);
    }

    public void Remove()
    {
        //FILL THIS IN LATER TO SUPPORT TOWERS.
    }
}
