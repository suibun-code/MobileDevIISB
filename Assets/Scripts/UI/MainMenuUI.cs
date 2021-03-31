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
    [SerializeField]
    Image sunImage;

    [SerializeField]
    private bool isLightUp;
    [SerializeField]
    private float alpha;

    public void StartButton()
    {
        GameManager.Instance.ChangeScene("GameScene");
        alpha = 0.5f;
    }
    void Update()
    {
        if(alpha > 0.7f)
        {
            isLightUp = false;
        }
        else if (alpha < 0.3f)
        {
            isLightUp = true;
        }

        if (isLightUp)
        {
            alpha += Time.deltaTime / 3;
            sunImage.color = new Color(1, 1, 1, alpha);
        }
        else
        {
            alpha -= Time.deltaTime / 3;
            sunImage.color = new Color(1, 1, 1, alpha);
        }
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
