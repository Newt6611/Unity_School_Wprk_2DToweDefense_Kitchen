using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : IEnemy
{
    void Awake()
    {
        Attack = GetComponent<ShootAttack>();
    }
}
