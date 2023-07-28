using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTarget : MonoBehaviour
{

    public GameObject target;
    float RandomX, RandomY;
    private float SpawnTime;
    public static bool targetSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        targetSpawn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetSpawn)
        {
            SpawnTarget();
        }
    }

    public void SpawnTarget()
    {
        RandomX = Random.Range(-3, 3);
        RandomY = Random.Range(-4, 4);

        Vector2 pos = new Vector2(RandomX, RandomY);
        Instantiate(target, pos, Quaternion.identity);
        targetSpawn = false;
    }
}
