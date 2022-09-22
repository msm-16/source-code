using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    void Start()
    {
        SystemManager.Instance.animEnd = false;
        SceneManager.SetActiveScene(gameObject.scene);
        SystemManager.Instance.sceneChanged = false;
        Time.timeScale = 1;
    }
}
