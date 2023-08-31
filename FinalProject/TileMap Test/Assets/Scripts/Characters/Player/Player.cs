using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP = 100;

    public int maxXP = 1;
    public int currentXP = 0;

    public int damage = 20;

    public void LevelUp()
    {
        currentXP = 0;
        maxHP += 10;
        damage += 5;
        currentHP = maxHP;
    }
}
