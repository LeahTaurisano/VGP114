using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    private ActionController controls;
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    [SerializeField] CombatTrigger combatActive;
    [SerializeField] Enemy boss;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] playerSprites;
    private void Awake()
    {
        controls = new ActionController();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        controls.Movement.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction)
    {
        if (CanMove(direction))
        {
            if(direction.y < 0) 
            {
                spriteRenderer.sprite = playerSprites[0];
            }
            else if (direction.y > 0) 
            {
                spriteRenderer.sprite = playerSprites[1];
            }
            else if (direction.x > 0) 
            {
                spriteRenderer.sprite = playerSprites[2];
            }
            else
            {
                spriteRenderer.sprite = playerSprites[3];
            }

            transform.position += (Vector3)direction;
        }
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition) || combatActive.flag || boss.currentHP <= 0) return false;
        return true;
    }
}
