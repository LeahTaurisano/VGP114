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
    GameObject spawnedEnemy;
    public int enemyCount = 0;

    [SerializeField] public Tilemap groundTilemap;
    [SerializeField] public Tilemap collisionTilemap;
    [SerializeField] CombatTrigger combatActive;

    void Update()
    {
        if (spawnTime <= 0)
        {
            if (enemyCount < enemyMaxCount)
            {
                spawnTime = spawnMaxTime;
                spawnedEnemy = Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
                MovementComponent enemyMovement = spawnedEnemy.AddComponent<MovementComponent>();
                enemyMovement.groundTilemap = groundTilemap;
                enemyMovement.collisionTilemap = collisionTilemap;
                enemyMovement.combatActive = combatActive;
                ++enemyCount;
            }
        }
        if (!combatActive.flag) spawnTime -= Time.deltaTime;
    }
}
