using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    Bounds spawnBounds;
    [SerializeField]
    GameObject[] prefab;
    [SerializeField]
    int spawnCount;

    static int count;

    static bool spawn;

    // Start is called before the first frame update
    void Start()
    {
        count = spawnCount;
        spawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnMoney();
            }
            spawn = false;
        }  
    }

    void SpawnMoney()
    {
        int rand = Random.Range(0, prefab.Length);

        var pos = transform.position;
        pos.x = Random.Range(spawnBounds.min.x, spawnBounds.max.x);
        pos.y = Random.Range(spawnBounds.min.y, spawnBounds.max.y);

        Quaternion qua = Quaternion.AngleAxis(Random.Range(0, 359), Vector3.forward);

        Instantiate(prefab[rand], pos, qua);
    }
    public static int GetSpawnCount()
    {
        return count;
    }
    public static void SetSpawn()
    {
        spawn = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnBounds.center, spawnBounds.size);
    }
    
}
