using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float spawnMaxTime = 10;
    private float spawnTime = 0;

    [SerializeField] private int enemyMaxCount = 10;
    [SerializeField] GameObject enemy;
    private int enemyCount = 0;

    void Update()
    {
        if (spawnTime <= 0)
        {
            spawnTime = spawnMaxTime;
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
        }
        spawnTime -= Time.deltaTime;
    }
}
