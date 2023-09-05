using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public bool isItemInRange;
    public Item itemInRange;

    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            isItemInRange = true;
            itemInRange = collision.GetComponent<Item>();
            inventory.addItem(itemInRange);
            Debug.Log("item added");

          

            inventory.PrintInventory();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
          
            Destroy(collision.gameObject);
        }
    }



}
