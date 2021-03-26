using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    GameObject optionPanel;
    [SerializeField]
    GameObject HowToPlayPanel;
    [SerializeField]
    GameObject CreditPanel;

    public void StartButton()
    {
        GameManager.Instance.ChangeScene("GameScene");
    }

    public void OptionWindowOpen()
    {
        optionPanel.SetActive(true);
    }
    public void OptionWindowClose()
    {
        optionPanel.SetActive(false);
    }
    public void HowToWindowOpen()
    {
        HowToPlayPanel.SetActive(true);
    }
    public void HowToWindowClose()
    {
        HowToPlayPanel.SetActive(false);
    }
    public void CreditWindowOpen()
    {
        CreditPanel.SetActive(true);
    }
    public void CreditWindowClose()
    {
        CreditPanel.SetActive(false);
    }
    public void LoadButton()
    {
        SaveManager.Instance.Load();
        GameManager.Instance.ChangeScene("GameScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
