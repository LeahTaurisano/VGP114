using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManagement : MonoBehaviour
{
    [SerializeField] CombatTrigger activeCombat;
    [SerializeField] Player player;

    [SerializeField] private TextMeshProUGUI playerHealthDisplay;
    [SerializeField] private TextMeshProUGUI enemyHealthDisplay;

    private bool isPlayerTurn = true;

    public void AttackButtonPressed()
    {
        if (isPlayerTurn)
        {
            // Check if an enemy is in range
            if (activeCombat.enemyInRange != null)
            {
                //damage enemy
                activeCombat.enemyInRange.TakeDamage(player.damage);
                enemyHealthDisplay.text = "Enemy HP: " + activeCombat.enemyInRange.currentHP;

                //if enemy hp is 0 destroy him
                if (activeCombat.enemyInRange.currentHP <= 0)
                {
                    activeCombat.flag = false;
                    activeCombat.enemyInRange.DestroyEnemy();
                    activeCombat.enemyInRange = null;
                    isPlayerTurn = true;
                    playerHealthDisplay.text = "Player HP: " + player.currentHP;
                    player.currentXP += 1;
                    if (player.currentXP >= player.maxXP) player.LevelUp();
                }
                else
                {
                    isPlayerTurn = false;
                }
            }
        }
    }


    void Update()
    {
      
        if (!isPlayerTurn)
        {
            //Enemy attack
            player.currentHP -= activeCombat.enemyInRange.damage;

            playerHealthDisplay.text = "Player HP: " + player.currentHP;

            isPlayerTurn = true;
        }
        

    }
}
