using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveObject : MonoBehaviour
{
    public CombatTrigger trigger;

    public GameObject combatUI;
    public GameObject menuUI;
    public GameObject inventoryMenuUI;

    public void AllMenuUIFalse()
    {
        menuUI.SetActive(false);
        inventoryMenuUI.SetActive(false);
    }
    public void ActivateCombatUI()
    {
        combatUI.SetActive(true);
        AllMenuUIFalse();
    }
    public void DeactivateCombatUI()
    {
        combatUI.SetActive(false);
    }

    private void Start()
    {
        AllMenuUIFalse();
    }

    void Update()
    {
        if (trigger.flag == true )
         {
             ActivateCombatUI();
         }
         else
         {
             DeactivateCombatUI();

         }
        if (Input.GetKeyDown(KeyCode.Escape) && !menuUI.active && !combatUI.active && !inventoryMenuUI.active)
        {
            menuUI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            AllMenuUIFalse();
        }

           

       
    }

    
}