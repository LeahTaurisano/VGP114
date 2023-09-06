using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManagement : MonoBehaviour
{
    [SerializeField] CombatTrigger activeCombat;
    [SerializeField] Player player;
    [SerializeField] GameObject playerSprite;
    [SerializeField] EnemySpawn spawner;
    [SerializeField] GameObject endUI;
    [SerializeField] EndgameText endtext;

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
                    activeCombat.enemyInRange = null;
                    isPlayerTurn = true;
                    playerHealthDisplay.text = "Player HP: " + player.currentHP;
                    player.currentXP += 1;
                    --spawner.enemyCount;
                    activeCombat.enemyInRange.DestroyEnemy();

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

            if (player.currentHP <= 0)
            {
                endUI.SetActive(true);
                playerSprite.SetActive(false);
                activeCombat.flag = false;
                Time.timeScale = 0;
                endtext.GameOver();
            }

            isPlayerTurn = true;
        }
        

    }
}
