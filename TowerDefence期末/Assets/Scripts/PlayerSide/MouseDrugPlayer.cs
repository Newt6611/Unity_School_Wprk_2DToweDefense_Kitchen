using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrugPlayer : IPlayer
{
    void Awake()
    {
        Attack = GetComponent<MouseDrugAttack>();
    }
}
