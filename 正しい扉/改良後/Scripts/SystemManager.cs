using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SystemManager : MonoBehaviour
{
    public static SystemManager Instance { get; private set; }

    public bool sceneChanged;
    public bool animEnd;

    string[] scenes = { "Title", "Game", "Clear", "Gameover" };

    int nowScene;
    int nextScene;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        animEnd = false;
        nowScene = 0;
        nextScene = 1;
        SceneManager.LoadScene(scenes[nowScene], LoadSceneMode.Additive);
    }

    void Update()
    {
        switch (nowScene)
        {
            case 0:
                nextScene = 1;
                break;
            case 1:
                if (GameManager.Instance.clear)
                {
                    nowScene = 2;
                }
                else if (GameManager.Instance.gameover)
                {
                    nowScene = 3;
                }
                break;
            case 2:
            case 3:
                nextScene = 0;
                break;
            default:
                break;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(animEnd)
            {
                ChangeScene();
            }
        }
        
    }

    public void ChangeScene()
    {
        /*
        Debug.Log("有効");
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (sceneChanged) return;

            sceneChanged = true;

            SceneManager.LoadScene(scenes[nextScene], LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(scenes[nowScene]);
            if (nowScene == 2 || nowScene == 3)
            {
                SceneManager.UnloadSceneAsync("Game");
            }
            nowScene = nextScene;
        }
        */
        if (sceneChanged) return;

        sceneChanged = true;

        SceneManager.LoadScene(scenes[nextScene], LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(scenes[nowScene]);
        if(nowScene == 2 || nowScene == 3)
        {
            SceneManager.UnloadSceneAsync("Game");
        }
        nowScene = nextScene;
        
    }
}
