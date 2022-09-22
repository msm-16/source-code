using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissManager : MonoBehaviour
{
    bool seFlag;

    int layerPlayer = 1 << 11;

    void Start()
    {
        seFlag = true;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 0.1f, layerPlayer)
         || Physics.Raycast(transform.position, transform.TransformDirection(new Vector3( 1, 0, 1)), 0.1f, layerPlayer)
         || Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(-1, 0, 1)), 0.1f, layerPlayer))
        {
            if(seFlag==true)
            {
                TinyAudio.PlaySE(TinyAudio.SE.Miss);
                seFlag = false;
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 0.1f, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3( 1, 0, 1)) * 0.1f, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-1, 0, 1)) * 0.1f, Color.yellow);
    }
}
