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
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Sprite[] allocatedEnemySprites;


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
                enemyMovement.enemySprites[0] = allocatedEnemySprites[0];
                enemyMovement.enemySprites[1] = allocatedEnemySprites[1];
                enemyMovement.enemySprites[2] = allocatedEnemySprites[2];
                enemyMovement.enemySprites[3] = allocatedEnemySprites[3];


                ++enemyCount;
            }
        }
        if (!combatActive.flag) spawnTime -= Time.deltaTime;
    }
}
