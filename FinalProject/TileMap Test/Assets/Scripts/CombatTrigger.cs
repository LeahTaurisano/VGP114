using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    public bool flag = false;
    public Enemy enemyInRange;

    [SerializeField] Player player;

    [SerializeField] private TextMeshProUGUI playerHealthDisplay;
    [SerializeField] private TextMeshProUGUI enemyHealthDisplay;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            flag = true;
            enemyInRange = collision.GetComponent<Enemy>(); //store enemy reference
            playerHealthDisplay.text = "Player HP: " + player.currentHP;
            enemyHealthDisplay.text = "Enemy HP: " + enemyInRange.currentHP;
        }
    }



    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            flag = false;
            enemyInRange = null; // Clear enemy ref
        }
    }
}
