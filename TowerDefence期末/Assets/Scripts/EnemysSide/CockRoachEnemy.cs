using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CockRoachEnemy : IEnemy
{
    void Awake()
    {
        base.Attack = GetComponent<MelleeAttack>();
    }

}
