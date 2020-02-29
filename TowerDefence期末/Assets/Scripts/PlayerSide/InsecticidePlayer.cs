using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsecticidePlayer : IPlayer
{
    public GameObject DizzyEffect;
    public Transform attackPos;

    void Awake()
    {
        Attack = GetComponent<MelleeAttack>();
    }

    void ShowDizzy()
    {
        Instantiate(DizzyEffect, attackPos.position, Quaternion.identity);
    }
}
