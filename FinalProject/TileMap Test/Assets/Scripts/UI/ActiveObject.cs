using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    public CombatTrigger trigger;

    public GameObject combatUI;

    public void ActivateCombatUI()
    {
        combatUI.SetActive(true);
    }

    public void DeactivateCombatUI()
    {
        combatUI.SetActive(false);
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
        

       
    }
}