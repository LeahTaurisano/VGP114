using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    private int healthPotionAmount;
    public void addItem(Item item)
    {
          items.Add(item);   
    }

    public void removeItem(Item item)
    {
        items.Remove(item);
    }
    public int getItemAmount(string itemName)
    {
        int amount = 0;
        foreach (Item item2 in items)
        {
            if(item2.itemName == itemName)
            {
                amount++;
            }
        }
        return amount;
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
