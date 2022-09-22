using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    public Image image;
    public Animator anim;

    bool animFlag;

    void Awake()
    {
        Instance = this;
        anim = gameObject.GetComponent<Animator>();
        animFlag = false;
        anim.SetBool("ColorChange", false);
    }

    void Update()
    {
        if (GameManager.Instance.start)
        {
            if(!animFlag)
            {
                anim.SetBool("ColorChange", true);
                animFlag = true;
            }
            
            image.fillAmount -= Time.deltaTime / 30;
            if(image.fillAmount<=0)
            {
                GameManager.Instance.ToGameover();
            }
        }
    }
}
