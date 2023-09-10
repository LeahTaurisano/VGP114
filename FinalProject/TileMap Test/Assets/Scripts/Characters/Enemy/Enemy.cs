using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHP = 100;
    public float maxHP = 100;
    public int damage = 5;
    public GameObject itemPrefab;

    // Reduce hp 
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }

    // Destroy enemy
    public void DestroyEnemy()
    {
        GameObject newItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);


    }
}
