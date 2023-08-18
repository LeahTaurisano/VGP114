using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressedDetector : MonoBehaviour
{
    public BattleManagement battleManager;

    public void OnButtonClick()
    {
        battleManager.AttackButtonPressed();
    }

}




