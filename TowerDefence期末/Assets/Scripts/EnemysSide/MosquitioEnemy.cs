using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitioEnemy : IEnemy
{
    void Awake()
    {
        Attack = GetComponent<ShootAttack>();
    }
}
