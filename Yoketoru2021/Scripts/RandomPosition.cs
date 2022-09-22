using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    [SerializeField]
    Bounds spawnBounds;

    void Awake()
    {
        var pos = transform.position;
        pos.x = Random.Range(spawnBounds.min.x, spawnBounds.max.x);
        pos.y = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
        transform.position = pos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnBounds.center, spawnBounds.size);
    }
}
