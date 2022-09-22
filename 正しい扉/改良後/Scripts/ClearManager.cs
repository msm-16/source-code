using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    void Start()
    {
        SystemManager.Instance.animEnd = false;
        SystemManager.Instance.sceneChanged = false;
        TinyAudio.StopBGM();
        TinyAudio.PlaySE(TinyAudio.SE.Clear);
    }
}
