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
    public Inventory inventory;
    [SerializeField] private TextMeshProUGUI healthPotionAmount;
    [SerializeField] private TextMeshProUGUI playerHealthDisplay;
    [SerializeField] private TextMeshProUGUI enemyHealthDisplay;

    private bool isPlayerTurn = true;

    public Image playerHealthBar;
    public Image playerEnergyBar;
    //public Image PlayerEXPBar;
    public Image enemyHealthBar;

    

    public void AttackButtonPressed()
    {
        if (isPlayerTurn)
        {
            // Check if an enemy is in range
            if (activeCombat.enemyInRange != null)
            {
                //damage enemy
                activeCombat.enemyInRange.TakeDamage(player.damage);
                enemyHealthBar.fillAmount = (activeCombat.enemyInRange.currentHP / activeCombat.enemyInRange.maxHP);
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
                    --spawner.enemyCount;

                    if (player.currentXP >= player.maxXP) player.LevelUp();     
                    
                }
                else
                {
                    isPlayerTurn = false;
                }
            }
        }
    }
    
    public void HealButtonPressed()
    {
        //Debug.Log("1");
        foreach (Item item in inventory.items)
        {
            //Debug.Log("2");
            if (item.itemName == "Potion")
            {
             //   Debug.Log("3");
                inventory.removeItem(item);
              //  Debug.Log("4");
                player.currentHP += 20;
                Debug.Log(player.currentHP);

                if (player.currentHP > player.maxHP)
                {
                    //Debug.Log("5");
                    player.currentHP = player.maxHP;
                }
                healthPotionAmount.text = "X" + inventory.getItemAmount("Potion").ToString();
                playerHealthDisplay.text = "Player HP: " + player.currentHP;
                playerHealthBar.fillAmount = player.currentHP / player.maxHP;
                // Debug.Log("6");
                
                break;
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
            
            playerHealthBar.fillAmount = player.currentHP / player.maxHP;
            playerEnergyBar.fillAmount = (player.currentEnergy / player.maxEnergy);

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
