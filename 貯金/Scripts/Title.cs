using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField]
    string nextScene;
    static bool next;

    static new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        next = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            next = true;
            PlaySE();
        }
            
        if (next && !audio.isPlaying)
            SceneManager.LoadScene(nextScene);
    }

    public static void PlaySE()
    {
        audio.PlayOneShot(audio.clip);
    }
    
}
