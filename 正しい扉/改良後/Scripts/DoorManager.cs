using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static DoorManager Instance { get; private set; }

    public GameObject key;
    public GameObject plzv;
    
    public Vector3 door;
    public Vector3 tfp;
    
    Vector3 angle;
    Vector3 rayPos;

    bool openFlag;

    int layerPlayer = 1 << 11;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        openFlag = false;
        rayPos = transform.position;
    }

    void Update()
    {
        if (Physics.Raycast(rayPos + tfp, transform.TransformDirection(Vector3.left), 2f, layerPlayer)
        ||  Physics.Raycast(rayPos - tfp, transform.TransformDirection(Vector3.left), 2f, layerPlayer))
        {
            if (KeyManager.Instance.keyFlag == true)
            {
                if (openFlag == false)
                {
                    plzv.SetActive(true);
                    if (Input.GetKey(KeyCode.V))
                    {
                        if(!GameManager.Instance.start)
                        {
                            GameManager.Instance.start = true;
                            GameManager.Instance.starttime = Time.time;
                            //Timer.Instance.anim.Play();
                        }
                        
                        plzv.SetActive(false);
                        TinyAudio.PlaySE(TinyAudio.SE.Open);
                        Open();
                    }
                }
            }
        }
        else
        {
            plzv.SetActive(false);
        }
        Debug.DrawRay(rayPos + tfp, transform.TransformDirection(Vector3.left) * 2f, Color.red);
        Debug.DrawRay(rayPos - tfp, transform.TransformDirection(Vector3.left) * 2f, Color.red);
    }

    void Open()
    {
        KeyManager.Instance.keyFlag = false;
        key.SetActive(true);
        angle = transform.eulerAngles;
        angle += door;
        transform.eulerAngles = angle;
        door = Vector3.zero;
        openFlag = true;
    }
}
