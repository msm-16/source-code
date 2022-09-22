using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    Vector3 angle;

    Quaternion targetRot;
    
    int layerWall = 1<<8;

    float target;
    float time;
    float startTime;

    void Start()
    {
        angle = transform.eulerAngles;
        target = transform.eulerAngles.y;
    }

    void Update()
    {
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 0.5f, layerWall)
         && !Physics.Raycast(transform.position, transform.TransformDirection(new Vector3( 1, 0, 1)), 0.5f, layerWall)
         && !Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(-1, 0, 1)), 0.5f, layerWall))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 0.5f, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3( 1, 0, 1)) * 0.5f, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-1, 0, 1)) * 0.5f, Color.red);

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            target += 180;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            target += 90;
        }
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {
            target += -90;
        }

        time += 1.5f * (Time.deltaTime - startTime);
        targetRot = Quaternion.AngleAxis(target, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, time);
    }
}
