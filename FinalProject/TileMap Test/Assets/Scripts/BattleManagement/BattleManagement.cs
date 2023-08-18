using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManagement : MonoBehaviour
{
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
            // Player attack
            enemyHP -= 10;
           
            Debug.Log("Enemy HP: " + enemyHP);
            isPlayerTurn = false;
        }
    }


    void Update()
    {
      
        if (!isPlayerTurn)
        {
            //Enemy attack
            playerHP -= 10; 

            Debug.Log("Player HP: " + playerHP);
      
            isPlayerTurn = true;
        }
        

    }
}
