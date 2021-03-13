using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultUI : MonoBehaviour
{
    // win image background
    public GameObject winImage;
    // game over image background
    public GameObject loseImage;
    // result text (win - score or lose - gameover)
    public Text resultText;

    void Start()
    {
        // win state
        if (GameManager.Instance.isWin)
        {
            winImage.SetActive(true);
            loseImage.SetActive(false);
            resultText.text = "Score: " + GameManager.Instance.score;
        }
        // lose state
        else
        {
            winImage.SetActive(false);
            loseImage.SetActive(true);
            resultText.text = "Game Over";
        }
    }
    // restart button
    public void RestartButton()
    {
        GameManager.Instance.ChangeScene("MainGame");
    }
    // mainmenu button
    public void MainmenuButton()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }
}
