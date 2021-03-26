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
    public float time;

    void Start()
    {
        loadingBar.fillAmount = 0.0f;
        StartCoroutine(LoadAsynSceneCoroutine());
    }

    //void Update()
    //{
    //    time += Time.deltaTime;
    //    loadingBar.fillAmount = time / 3f;

    //    if (time > 3.0f)
    //    {
    //        time = 0;
    //        GameManager.Instance.ChangeScene("GameScene");
    //    }
    //}

    IEnumerator LoadAsynSceneCoroutine()
    {
        // if loading already finish, wait until 5 second (too short).
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        operation.allowSceneActivation = false;


        while (!operation.isDone)
        {

            time += Time.deltaTime;

            loadingBar.fillAmount = time / 3f;

            if (time > 3)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

    }
}
