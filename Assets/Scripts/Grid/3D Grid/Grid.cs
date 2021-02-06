using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public enum CellState
{
    None, Enemy, Free, OutOfBounds
}

public class Grid : MonoBehaviour
{
    [SerializeField]
    public static int CellSizeZ = 6;
    [SerializeField]
    public static int CellSizeX = 3;

    public GameObject cellPrefab;
    public Cell[,] allCells = new Cell[CellSizeX, CellSizeZ];

    public void Init()
    {
        for (int i = 0; i < CellSizeZ; i++)
            for (int j = 0; j < CellSizeX; j++)
            {
                GameObject newCell = Instantiate(cellPrefab, transform);

                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.position = new Vector3((j * 18) - 18f, rectTransform.position.y, (i * 24) - 60f);

                allCells[j, i] = newCell.GetComponent<Cell>();
                allCells[j, i].Setup(new Vector2Int(j, i), this);
            }

        //for (int i = 0; i < CellSizeX; i += 2)
        //    for (int j = 0; j < CellSizeZ; j++)
        //    {
        //        int offset = (j % 2 != 0) ? 0 : 1;
        //        int finalX = i + offset;

        //        allCells[finalX, j].GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 30);
        //    }
    }
}
