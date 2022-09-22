using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    public static ToNextScene Instance { get; private set; }

    [Tooltip("切り替えたいシーン名"), SerializeField]
    public string nextScene = "";

    bool sceneChanged;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        if (sceneChanged) return;

        sceneChanged = true;
        SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
    }
}
