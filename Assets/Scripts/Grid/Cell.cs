using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public TowerManager towerManager;

    public SpriteRenderer spriteRenderer;
    public Tower currentTower = null;
    public Vector2Int gridPosition = Vector2Int.zero;
    public Board Board = null;
    public RectTransform rectTransform = null;


    public void Setup(Vector2Int newGridPosition, Board newBoard)
    {
        gridPosition = newGridPosition;
        Board = newBoard;

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
