using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellState
{
    None, Enemy, Free, OutOfBounds
}

public class Grid : MonoBehaviour
{
    [SerializeField]
    public static int CellSizeZ = 32;
    [SerializeField]
    public static int CellSizeX = 12;

    public GameObject cellPrefab;
    public Cell[,] allCells = new Cell[CellSizeZ, CellSizeX];

    public void Init()
    {
        for (int i = 0; i < CellSizeZ; i++)
        {
            for (int j = 0; j < CellSizeX; j++)
            {
                Debug.Log("Grid Init For Loop");
                GameObject newCell = Instantiate(cellPrefab, transform);

                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.position = new Vector3((j * 4) - 22f, rectTransform.position.y, (i * 4) - 62f);

                if (GetComponent<Cell>() != null)
                {
                    allCells[j, i] = newCell.GetComponent<Cell>();
                    allCells[j, i].Setup(new Vector2Int(j, i), this);
                }
            }
        }
    }
}
