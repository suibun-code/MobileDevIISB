using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUI : MonoBehaviour
{
    public GameObject optionPanel;

    public void OptionOpen()
    {
        optionPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void OptionClose()
    {
        optionPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
