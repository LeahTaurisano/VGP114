using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManagement : MonoBehaviour
{
    [SerializeField] CombatTrigger activeCombat;
    private ButtonPressedDetector buttonPressedDetector;
    private Player player;
    private Enemy enemy;

    private int playerHP;
    private int enemyHP;
    private bool isPlayerTurn;

    private bool buttonIsPressed;

    void Start()
    {
        buttonPressedDetector = FindObjectOfType<ButtonPressedDetector>();
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();

        isPlayerTurn = true;

        playerHP = player.currentHP;
        enemyHP = enemy.currentHP;
        Debug.Log("Player HP: " + playerHP);
        Debug.Log("Enemy HP: " + enemyHP);

    }

    // Update is called once per frame

    public void AttackButtonPressed()
    {
        if (isPlayerTurn)
        {
            // Check if an enemy is in range
            if (activeCombat.enemyInRange != null)
            {
                //damage enemy
                activeCombat.enemyInRange.TakeDamage(20);
                enemyHP = activeCombat.enemyInRange.currentHP;

                Debug.Log("Enemy HP: " + enemyHP);

                //if enemy hp is 0 destroy him
                if (enemyHP <= 0)
                {
                    activeCombat.flag = false;
                    activeCombat.enemyInRange.DestroyEnemy();
                    activeCombat.enemyInRange = null;
                    isPlayerTurn = true;
                    playerHP = 100;
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
            playerHP -= 5; 

            Debug.Log("Player HP: " + playerHP);
      
            isPlayerTurn = true;
        }
        

    }
}
