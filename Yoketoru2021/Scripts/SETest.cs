using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SETest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TinyAudio.PlaySE(TinyAudio.SE.Click);
        }
        if (Input.GetMouseButtonDown(1))
        {
            TinyAudio.PlaySE(TinyAudio.SE.Start);
        }
        
    }
}
