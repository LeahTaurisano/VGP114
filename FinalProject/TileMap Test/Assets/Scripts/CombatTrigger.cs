using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    public bool flag = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
      

        if (collision.CompareTag("Enemy"))
        {
            flag = true;
        }
    }
}
