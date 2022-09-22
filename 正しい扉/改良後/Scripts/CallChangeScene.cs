using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallChangeScene : MonoBehaviour
{
    ToNextScene toNextScene;

    void Start()
    {
        toNextScene = GetComponent<ToNextScene>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Next"))
        {
            toNextScene.ChangeScene();
        }
    }
}
