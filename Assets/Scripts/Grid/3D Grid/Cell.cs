using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Vector2Int gridPosition = Vector2Int.zero;
    public Grid grid = null;
    public RectTransform rectTransform = null;

    public void Setup(Vector2Int newGridPosition, Grid newGrid)
    {
        gridPosition = newGridPosition;
        grid = newGrid;

        rectTransform = GetComponent<RectTransform>();
    }

    public void Remove()
    {
        //FILL THIS IN LATER TO SUPPORT TOWERS.
    }
}
