using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    [SerializeField]
    int point = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            TinyAudio.PlaySE(TinyAudio.SE.Click);

            GameManager.AddPoint(point);
        }
    }
}
