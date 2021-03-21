using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region singleton
    private static SaveManager instance = null;

    private void Awake()
    {
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

    public static SaveManager Instance
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
   
    // Save Function
    public void Save()
    {
        PlayerPrefs.SetFloat("pyramidHP", GameManager.Instance.pyramidHP);
        PlayerPrefs.SetInt("score", GameManager.Instance.score);

        // save player resource
        // save enemy position and status
    }

    // Load Function
    public void Load()
    {
        GameManager.Instance.pyramidHP = PlayerPrefs.GetFloat("pyramidHP");
        GameManager.Instance.score = PlayerPrefs.GetInt("score");

        // load player resource
        // load enemy position and status
    }

    // Save bool variable function
    public static void SetBool(string key, bool value)
    {
        if (value)
            PlayerPrefs.SetInt(key, 1);
        else
            PlayerPrefs.SetInt(key, 0);
    }
    // Load bool variable function
    public static bool GetBool(string key)
    {
        int value = PlayerPrefs.GetInt(key);
        if (value == 1)
            return true;

        else
            return false;
    }
    // save vector function
    public static void SetVector3(string key, Vector3 value)
    {
        PlayerPrefs.SetFloat(key + "X", value.x);
        PlayerPrefs.SetFloat(key + "Y", value.y);
        PlayerPrefs.SetFloat(key + "Z", value.z);

    }
    // load vector function
    public static Vector3 GetVector3(string key)
    {
        Vector3 v3 = Vector3.zero;
        v3.x = PlayerPrefs.GetFloat(key + "X");
        v3.y = PlayerPrefs.GetFloat(key + "Y");
        v3.z = PlayerPrefs.GetFloat(key + "Z");
        return v3;
    }
}
