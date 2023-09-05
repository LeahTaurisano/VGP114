using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void addItem(Item item)
    {
          items.Add(item);   
    }

    public void removeItem(Item item)
    {
        items.Remove(item);
    }
    public void PrintInventory()
    {
        Debug.Log("Player Inventory:");

        foreach (Item item in items)
        {
            Debug.Log("Name: " + item.itemName);
        }
    }
}
