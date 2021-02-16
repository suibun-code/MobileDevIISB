using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject towerPrefab;
    public Grid grid;

    //Audio
    [Header("Audio")]
    public AudioClip PlacingTowerSFX;
    public void CreateTower(Cell cellToPlaceIn)
    {

        if (ResourceInventorySystem.bricks >= 10 && ResourceInventorySystem.gold >= 5 && ResourceInventorySystem.diamond >= 2)
        {
            ResourceInventorySystem.bricks = ResourceInventorySystem.bricks - 10;
            ResourceInventorySystem.gold = ResourceInventorySystem.gold - 5;
            ResourceInventorySystem.diamond = ResourceInventorySystem.diamond - 2;

            Debug.Log("Create tower");

            GameObject newTower = Instantiate(towerPrefab);

            int targetX = cellToPlaceIn.gridPosition.x;
            int targetY = cellToPlaceIn.gridPosition.y;
            Tower towerComponent = newTower.GetComponent<Tower>();

            towerComponent.SetCell(cellToPlaceIn);

            //audio
            //AudioSource.PlayClipAtPoint(PlacingTowerSFX, transform.position);
        }
        else
            Debug.Log("You don't meet the resource requirement to build a tower!");

    }
}
