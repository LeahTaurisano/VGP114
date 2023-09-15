using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovementComponent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Tilemap groundTilemap;
    [SerializeField] public Tilemap collisionTilemap;
    [SerializeField] public CombatTrigger combatActive;
    float moveCD = 3;
    int randDir;
    Vector2 Direction;


    [SerializeField] private SpriteRenderer spriteRenderer;
    public Sprite[] enemySprites;

    public void Start()
    {
        GameObject collisionTilemap = GameObject.FindGameObjectWithTag("Ground1");
    }
    public void Update()
    {
        if (moveCD <= 0)
        {
            randDir = Random.Range(0, 3);
            switch (randDir)
            {
                case 0:
                    Direction = new Vector2(1, 0);
                    spriteRenderer.sprite = enemySprites[0];
                    break;
                case 1:
                    Direction = new Vector2(-1, 0);
                    spriteRenderer.sprite = enemySprites[1];
                    break;
                case 2:
                    Direction = new Vector2(0, 1);
                    spriteRenderer.sprite = enemySprites[2];
                    break;
                case 3:
                    Direction = new Vector2(0, -1);
                    spriteRenderer.sprite = enemySprites[3];
                    break;

            }
            Move(Direction);
            moveCD = 3;
        }
        else
        {
            moveCD -= Time.deltaTime;
        }
    }
    public void Move(Vector2 direction)
    {
        if (CanMove(direction))
        {
            transform.position += (Vector3)direction;
        }
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition) || combatActive.flag) return false;
        return true;
    }
}
