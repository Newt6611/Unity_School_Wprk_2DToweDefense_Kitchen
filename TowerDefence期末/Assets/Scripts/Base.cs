using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public int StartHP;
    private int HP;

    public Image healthBar;

    void Start()
    {
        HP = StartHP;
    }

    void Update()
    {
        healthBar.fillAmount = (float)HP / StartHP;

        if (HP <= 0f)
        {
            GameManager.SetWinOrLose(WinGameOrLoasGame.lose);
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }
}
