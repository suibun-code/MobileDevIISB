using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public TowerManager towerManager;

    public SpriteRenderer spriteRenderer;
    public Tower currentTower = null;
    public Vector2Int gridPosition = Vector2Int.zero;
    public Grid grid = null;
    public RectTransform rectTransform = null;

    public void Setup(Vector2Int newGridPosition, Grid newGrid)
    {
        gridPosition = newGridPosition;
        grid = newGrid;

        rectTransform = GetComponent<RectTransform>();
    }

    void OnMouseDown()
    {
        towerManager.CreateTower(this);
    }

    public void Remove()
    {
        //FILL THIS IN LATER TO SUPPORT TOWERS.
    }
}