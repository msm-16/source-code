using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderManager : MonoBehaviour
{
    static float add = 0.5f;

    public static void E()
    {
        add = 0f;
    }

    void Update()
    {
        transform.Rotate(0, add, 0);
    }
}
