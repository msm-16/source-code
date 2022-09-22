using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance { get; private set; }

    [SerializeField]
    private new GameObject gameObject;

    public bool keyFlag;

    int layerPlayer = 1<<11;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        keyFlag = true;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 0.5f, layerPlayer)
         || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), 0.5f, layerPlayer)
         || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), 0.5f, layerPlayer)
         || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), 0.5f, layerPlayer))
        {
            keyFlag = true;
            TinyAudio.PlaySE(TinyAudio.SE.Get);
            gameObject.SetActive(false);
        }
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 0.5f, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * 0.5f, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 0.5f, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 0.5f, Color.yellow);
    }
}
