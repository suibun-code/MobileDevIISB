using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public void StartButton()
    {
        GameManager.Instance.ChangeScene("Loading");
    }
}
