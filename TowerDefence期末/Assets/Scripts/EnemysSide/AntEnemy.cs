using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntEnemy : IEnemy
{
    void Awake()
    {
        Attack = GetComponent<MelleeAttack>();
    }
}
