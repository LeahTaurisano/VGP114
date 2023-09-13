using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatTrigger : MonoBehaviour
{
    public bool flag = false;
    public Enemy enemyInRange;

    [SerializeField] Player player;

    [SerializeField] private TextMeshProUGUI playerHealthDisplay;
    [SerializeField] private TextMeshProUGUI enemyHealthDisplay;

    public Image playerHealthBar;
    public Image PlayerEXPBar;
    public Image enemyHealthBar;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            flag = true;
            enemyInRange = collision.GetComponent<Enemy>(); //store enemy reference
            playerHealthDisplay.text = "Player HP: " + player.currentHP;
            playerHealthBar.fillAmount = (player.currentHP / player.maxHP);
            enemyHealthDisplay.text = "Enemy HP: " + enemyInRange.currentHP;
            enemyHealthBar.fillAmount = (enemyInRange.currentHP / enemyInRange.maxHP);
            PlayerEXPBar.fillAmount = player.currentXP / player.maxXP;
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
