using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameUI : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject pausePanel;
    public GameObject saveText;

    public void OptionOpen()
    {
        optionPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void OptionClose()
    {
        optionPanel.SetActive(false);
        Time.timeScale = 1.0f;
        saveText.SetActive(false);
    }

    public void SaveButton()
    {
        SaveManager.Instance.Save();
        saveText.SetActive(true);
    }

    public void PauseOpen()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void PauseClose()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void MainMenu()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }
}
