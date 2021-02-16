using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingUI : MonoBehaviour
{
    // loaing slide UI
    public Image loadingBar;
    // scene name
    public string SceneName;
    //increse the time
    private float time;

    void Start()
    {
        loadingBar.fillAmount = 0.0f;
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

            loadingBar.fillAmount = time / 3f;

            if (time > 5)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

    }
}
