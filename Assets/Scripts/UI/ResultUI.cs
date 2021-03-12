using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    public string SceneName;
    public float time;

    public void RestartButton()
    {
        SceneName = "tempPathScene";
        StartCoroutine(LoadAsynSceneCoroutine());
    }
    public void MainmenuButton()
    {
        SceneName = "MainMenu";
        StartCoroutine(LoadAsynSceneCoroutine());
    }


    IEnumerator LoadAsynSceneCoroutine()
    {
        // if loading already finish, wait until 5 second (too short).
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        operation.allowSceneActivation = false;


        while (!operation.isDone)
        {

            time += Time.deltaTime;

            //loadingBar.fillAmount = time / 3f;

            if (time > 0.1)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

    }
}


