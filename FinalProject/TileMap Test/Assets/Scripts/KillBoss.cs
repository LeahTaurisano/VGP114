using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoss : MonoBehaviour
{
    [SerializeField] GameObject endUI;
    [SerializeField] EndgameText endtext;
    [SerializeField] Enemy boss;

    public void Update()
    {
        if (boss.currentHP <= 0)
        {
            WinGame();
        }
    }
    public void WinGame()
    {
        Destroy(gameObject);
        endUI.SetActive(true);
        Time.timeScale = 0;
        endtext.Victory();
    }
}
