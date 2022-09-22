using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Over : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI point;

    static new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        point.text = GameManager.GetPoint()+"‰~";
    }

    public static bool GetPlaySE()
    {
        return audio.isPlaying;
    }
}
