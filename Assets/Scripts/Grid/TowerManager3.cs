using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TowerToBuild
{
    Sniper = 0,
    Canon = 1
}
public class TowerManager3 : MonoBehaviour
{
    [SerializeField]
    public GameObject[] towerPrefabs;
    [SerializeField]
    public static TowerToBuild towerToBuild = TowerToBuild.Sniper;

    public GameObject board;

    //Audio
    [Header("Audio")]
    public AudioClip PlacingTowerSFX;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            towerToBuild = TowerToBuild.Sniper;
            // Debug.Log("Now building sniper towers.");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            towerToBuild = TowerToBuild.Canon;
            // Debug.Log("Now building canon towers.");
        }
    }

    public void CreateTower(Cell cellToPlaceIn)
    {
        if (!(ResourceInventorySystem.bricks >= 10 && ResourceInventorySystem.gold >= 5 &&
              ResourceInventorySystem.diamond >= 2))
        {
            Debug.Log("You don't meet the resource requirement to build a tower!");
            return;
        }

        ResourceInventorySystem.bricks -= 10;
        ResourceInventorySystem.gold -= 5; ;
        ResourceInventorySystem.diamond -= 2;

        Debug.Log("Create tower");

        Debug.Log("test: " + (int)towerToBuild);

        GameObject newTower = Instantiate(towerPrefabs[(int)towerToBuild]);

        int targetX = cellToPlaceIn.gridPosition.x;
        int targetY = cellToPlaceIn.gridPosition.y;
        Tower towerComponent = newTower.GetComponent<Tower>();

        towerComponent.SetCell(cellToPlaceIn);

        //audio
        AudioSource.PlayClipAtPoint(PlacingTowerSFX, transform.position);

        if (!(ResourceInventorySystem.bricks >= 10 && ResourceInventorySystem.gold >= 5 &&
           ResourceInventorySystem.diamond >= 2))
        {
            Debug.Log("Ran out of resources! Can not make more towers.");

            ToggleBoard.buildText.color = Color.red;
            ToggleBoard.buildText.text = "Can not build.";
        }
    }

    public void SetTowerToBuild(int nextTower)
    {
        towerToBuild = (TowerToBuild)nextTower;
    }
}
