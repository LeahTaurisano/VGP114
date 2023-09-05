using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButtonPressed : MonoBehaviour
{
    public BattleManagement battleManager;

    public void OnButtonClick()
    {
       
        battleManager.HealButtonPressed();
    }
}
