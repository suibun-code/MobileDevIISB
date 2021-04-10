using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBoard : MonoBehaviour
{
    public GameObject board;
    public GameObject buildTextObject;
    public static TMP_Text buildText;
    public static Button btn;

    public GameObject sniperBtn;
    public GameObject canonBtn;

    public void Awake()
    {
        buildText = buildTextObject.GetComponent<TMP_Text>();
        btn = GetComponent<Button>();

    }

    public void Start()
    {
        sniperBtn.SetActive(false);
        canonBtn.SetActive(false);

        if (ResourceInventorySystem.bricks >= 5 && ResourceInventorySystem.gold >= 3 &&
            ResourceInventorySystem.diamond >= 1)
        {
            ToggleBoard.buildText.color = Color.green;
            ToggleBoard.buildText.text = "Can build.";
        }
        else
        {
            ToggleBoard.buildText.color = Color.red;
            ToggleBoard.buildText.text = "Can not build.";
        }
    }

    public void Toggle()
    {
        if (board.activeInHierarchy)
        { 
            board.SetActive(false);
            sniperBtn.SetActive(false);
            canonBtn.SetActive(false);
        }
        else
        {
            if (!(ResourceInventorySystem.bricks >= 5 && ResourceInventorySystem.gold >= 3 &&
                  ResourceInventorySystem.diamond >= 1))
            {
                Debug.Log("You don't meet the resource requirement to build a tower!");
                return;
            }

            board.SetActive(true);
            sniperBtn.SetActive(true);
            canonBtn.SetActive(true);
        }

    }
}
