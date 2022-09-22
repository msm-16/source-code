using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NCMB;

public class CallChangeScene : MonoBehaviour
{
    ToNextScene toNextScene;

    // Start is called before the first frame update
    void Start()
    {
        toNextScene = GetComponent<ToNextScene>();
    }

    // Update is called once per frame
    void Update()
    {
        var rank = SceneManager.GetSceneByName("Ranking");
        if (rank.IsValid()) return;

        if (Input.GetButtonUp("Next"))
        {
            toNextScene.ChangeScene();
        }
    }
}
