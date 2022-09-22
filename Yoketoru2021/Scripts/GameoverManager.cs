using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverManager : MonoBehaviour
{
    void Start()
    {
        TinyAudio.StopBGM();
        TinyAudio.PlaySE(TinyAudio.SE.Gameover);
    }
}
