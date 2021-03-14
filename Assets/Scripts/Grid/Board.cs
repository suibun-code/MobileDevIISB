using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellState
{
    None, Enemy, Free, OutOfBounds
}

public class Board : MonoBehaviour
{
    [SerializeField]
    public static int CellSizeZ = 24;
    [SerializeField]
    public static int CellSizeX = 10;

    public GameObject cellPrefab;
    public Cell[,] allCells = new Cell[CellSizeX, CellSizeZ];

    public void Init()
    {
        gameObject.SetActive(false);

        for (int i = 0; i < CellSizeZ; i++)
            for (int j = 0; j < CellSizeX; j++)
            {
                GameObject newCell = Instantiate(cellPrefab, transform);

                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.position = new Vector3((j * 4) - 14.5f, rectTransform.position.y, (i * 4) - 60f);

                allCells[j, i] = newCell.GetComponent<Cell>();
                allCells[j, i].Setup(new Vector2Int(j, i), this);
            }

        for (int i = 0; i < CellSizeX; i += 2)
            for (int j = 0; j < CellSizeZ; j++)
            {
                int offset = (j % 2 != 0) ? 0 : 1;
                int finalX = i + offset;

                allCells[finalX, j].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 128);
            }
    }
}
