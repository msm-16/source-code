using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    int layerPlayer = 1 << 11;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 0.1f, layerPlayer)
         || Physics.Raycast(transform.position, transform.TransformDirection(new Vector3( 1, 0, 1)), 0.1f, layerPlayer)
         || Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(-1, 0, 1)), 0.1f, layerPlayer))
        {
            GameManager.ToClear();
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 0.1f, Color.blue);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3( 1, 0, 1)) * 0.1f, Color.blue);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-1, 0, 1)) * 0.1f, Color.blue);
    }
}
