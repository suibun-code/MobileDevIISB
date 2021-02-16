using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  During this build you press the Keys 1, 2, 3 to add one of the resource items. (It will change in the next build)

public class ResourceInventorySystem : MonoBehaviour
{
    // Text to change the resource Value
    public Text bricksCtr;
    public Text goldCtr;
    public Text diamondCtr;

    // int counter for the 3 resources
    public static int bricks, gold, diamond;

    Cell cellSpt;

    // Start is called before the first frame update
    void Start()
    {
        bricks = 0;
        gold = 0;
        diamond = 0;

        cellSpt = GetComponent<Cell>();
    }

    // Update is called once per frame
    void Update()
    {
        bricksCtr.text = "" + bricks;
        goldCtr.text = "" + gold;
        diamondCtr.text = "" + diamond;

        CollectBricks();
        CollectGold();
        CollectDiamond();
    }

    // functions to 1 items to your resource
    void CollectBricks()
    {
        // bricks++;
        if (Input.GetKeyUp(KeyCode.Alpha1) && bricks < 50) // press 1 key to add one brick
        {
            bricks++;
        }
    }

    void CollectGold()
    {
        //gold++;
        if (Input.GetKeyUp(KeyCode.Alpha2) && gold < 50) // press 2 key to add one gold
        {
            gold++;
        }
    }

    void CollectDiamond() 
    {

        //diamond++;
        if (Input.GetKeyUp(KeyCode.Alpha3) & diamond < 50) // press 3 key to add one diamond
        {
            diamond++;
        }
    }
}
