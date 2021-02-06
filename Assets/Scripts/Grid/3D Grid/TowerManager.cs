using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject towerPrefab;
    public Grid grid;

    public AudioClip SFX;
    public void CreateTower(Cell cellToPlaceIn)
    {
        Debug.Log("Create tower");

        GameObject newTower = Instantiate(towerPrefab);

        int targetX = cellToPlaceIn.gridPosition.x;
        int targetY = cellToPlaceIn.gridPosition.y;
        Tower towerComponent = newTower.GetComponent<Tower>();

        towerComponent.SetCell(cellToPlaceIn);

        AudioSource.PlayClipAtPoint(SFX, transform.position);
    }
}
