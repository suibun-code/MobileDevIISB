using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // singleton pattern
    #region singleton
    private static GameManager instance = null;

    private void Awake()
    {
        brick = 40;
        gold = 20;
        diamond = 8;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    #endregion

    // win state (use for result scene)
    public bool isWin;
    // player score
    public int score;
    // player hp
    public float pyramidHP;
    // player hp
    public int brick;
    // player hp
    public int gold;
    // player hp
    public int diamond;
    // wave Number
    public int waveNum;


    // Change scene
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
