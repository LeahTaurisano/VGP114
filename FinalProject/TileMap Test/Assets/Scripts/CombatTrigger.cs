using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    public bool flag = false;
    public Enemy enemyInRange;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            flag = true;
            enemyInRange = collision.GetComponent<Enemy>(); //store enemy reference
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
