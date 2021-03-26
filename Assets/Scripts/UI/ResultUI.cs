using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void OnRestartPressed()
    {
        GameManager.Instance.ChangeScene("GameScene");
    }

    public void OnMenuPressed()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }
}
