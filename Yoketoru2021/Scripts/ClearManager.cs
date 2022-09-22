using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TinyAudio.PlayBGM(TinyAudio.BGM.Clear);
    }
}
