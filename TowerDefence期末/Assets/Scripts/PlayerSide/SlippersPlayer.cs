using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlippersPlayer : IPlayer
{
    void Awake()
    {
        Attack = GetComponent<ShootAttack>();
        canRotation = true;
    }
}
