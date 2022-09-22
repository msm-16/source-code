using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    string nowScene;
    void Start()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Additive);
        nowScene = "Title";
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ToNextScene.Instance.ChangeScene();
        }
    }
}
