using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    void Start()
    {
        TinyAudio.StopBGM();
        TinyAudio.PlaySE(TinyAudio.SE.Clear);
    }
}
