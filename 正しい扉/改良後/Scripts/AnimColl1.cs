using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimColl1 : MonoBehaviour
{
    public void Call1()
    {
        SystemManager.Instance.animEnd = true;
    }
}
