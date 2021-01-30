using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public void RestartButton()
    {
        GameManager.Instance.ChangeScene("MainGame");
    }
    public void MainmenuButton()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }
}
