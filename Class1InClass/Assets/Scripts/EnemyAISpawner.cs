using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAISpawner : MonoBehaviour
{

    public GameObject EnemyAI;
    float RandomX, RandomY;
    private float SpawnTime;
    public static bool enemySpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(enemySpawn)
        {
            EnemyAiSpawner();
        }
    }

    public void EnemyAiSpawner()
    {
        RandomX = Random.Range(-3, 3);
        RandomY = Random.Range(-4, 4);

        Vector2 pos = new Vector2(RandomX, RandomY);
        Instantiate(EnemyAI, pos, Quaternion.identity);
        enemySpawn = false;
    }
}
