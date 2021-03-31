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
    // win moving object
    public GameObject sunObj;
    // lose moving object
    public GameObject loseObj;

    public float turnSpeed = 1;

    private float moveY = 0.05f;
    private bool isMoveUp;
    private float time;

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
    
    void Update()
    {
        sunObj.transform.Rotate(new Vector3(0, 0, turnSpeed));

        time += Time.deltaTime;
        if(time > 0.5f)
        {
            time = 0;
            if (isMoveUp)
                isMoveUp = false;
            else
                isMoveUp = true;
        }
        if (isMoveUp)
        {
            loseObj.transform.Translate(new Vector3(0, moveY, 0));
        }
        else
        {
            loseObj.transform.Translate(new Vector3(0, -moveY, 0));
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
