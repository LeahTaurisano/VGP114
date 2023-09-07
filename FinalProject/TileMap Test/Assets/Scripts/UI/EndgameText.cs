using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndgameText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EndScreen;

    public void GameOver()
    {
        EndScreen.text = "Game Over";
    }

    public void Victory()
    {
        EndScreen.text = "Victory!";
    }
}
