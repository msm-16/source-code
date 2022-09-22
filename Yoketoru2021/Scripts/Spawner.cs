using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static void Spawne(int spawnCount, GameObject prefab)
    {
        for (int i=0;i<spawnCount;i++)
        {
            Instantiate(prefab);
        }
    }
}
