using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Cell currentCell = null;
    protected List<Cell> cellsInRange = new List<Cell>();

    public void SetCell(Cell newCell)
    {
        currentCell = newCell;
        currentCell.currentTower = this;
        transform.position = new Vector3(newCell.transform.position.x, 3.5f, newCell.transform.position.z);
    }
}
