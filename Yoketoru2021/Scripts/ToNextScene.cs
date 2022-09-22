using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NCMB;

public class ToNextScene : MonoBehaviour
{
    [Tooltip("切り替えたいシーン名"), SerializeField]
    string nextScene = "";

    bool sceneChanged;

    public void ChangeScene()
    {
        if (sceneChanged) return;

        sceneChanged = true;
        SceneManager.LoadScene(nextScene);
    }
}
