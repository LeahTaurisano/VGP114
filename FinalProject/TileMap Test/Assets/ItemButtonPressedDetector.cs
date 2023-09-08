using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButtonPressedDetector : MonoBehaviour
{
        public BattleManagement battleManager;
        public void OnButtonClick()
        {

        battleManager.HealButtonPressed();

        } 
}
