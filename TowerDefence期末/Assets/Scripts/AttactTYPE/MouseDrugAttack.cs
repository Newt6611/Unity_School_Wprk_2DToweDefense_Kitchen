using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrugAttack : MonoBehaviour, IAttack
{
    [SerializeField] private GameObject mouseDrugPre;
    [SerializeField] private Transform shootPos;
    public void attack()
    {
        Instantiate(mouseDrugPre, shootPos.position, Quaternion.identity);
    }

}
