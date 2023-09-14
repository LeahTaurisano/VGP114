using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressedDetector : MonoBehaviour
{
    public BattleManagement battleManager;
    public ActiveObject UIactivation;

    [SerializeField] Player player;
    public Inventory inventory;
    [SerializeField] private TextMeshProUGUI healthPotionAmountInventory;
    [SerializeField] private TextMeshProUGUI playerHealthInventory;
    [SerializeField] private TextMeshProUGUI playerDamageInventory;
    public void OnButtonClick()
    {
        battleManager.AttackButtonPressed();
    }

   public void onInventoryButtonClick()
    {
        UIactivation.inventoryMenuUI.SetActive(true);
        UIactivation.menuUI.SetActive(false);
        playerHealthInventory.text = "HP: " + player.currentHP + "/" + player.maxHP;
        playerDamageInventory.text = "DMG: " + player.damage;
        healthPotionAmountInventory.text = inventory.getItemAmount("Potion").ToString();

    }
    public void OnExitButtonClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}




