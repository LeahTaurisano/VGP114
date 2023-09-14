using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP = 100;

    public float maxXP = 1;
    public float currentXP = 0;

    public float maxEnergy = 20;
    public float currentEnergy = 20;

    public int damage = 20;

    public void LevelUp()
    {
        currentXP = 0;
        maxHP += 10;
        maxEnergy += 5;
        damage += 5;
        currentHP = maxHP;
    }
}
