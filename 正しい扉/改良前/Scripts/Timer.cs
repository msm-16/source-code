using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image image;

    void Update()
    {
        if (GameManager.Instance.start)
        {
            image.fillAmount -= Time.deltaTime / 20;
            if(image.fillAmount<=0)
            {
                GameManager.ToGameover();
            }
        }
    }
}
