using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyroll : MonoBehaviour
{
    static float add = 0.5f;

    void Update()
    {
        transform.Rotate(0, add, 0);
    }
}
