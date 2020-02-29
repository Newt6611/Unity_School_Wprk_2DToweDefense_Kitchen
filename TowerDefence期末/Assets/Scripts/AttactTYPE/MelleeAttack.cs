using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleeAttack : MonoBehaviour, IAttack
{
    [SerializeField] Transform attactPos;
    [SerializeField] private float attactRange;
    [SerializeField] private LayerMask whatIsTheTarget;
    public int damage;
    public void attack()
    {
        Collider2D[] targetToDmage = Physics2D.OverlapCircleAll(attactPos.position, attactRange, whatIsTheTarget);
        for (int i = 0; i < targetToDmage.Length; i++)
        {
            if (gameObject.tag == "Insecticide")
            {
                if (targetToDmage[i].tag == "Ant")
                {
                    targetToDmage[i].GetComponent<IEnemy>().TakeDamage(3);
                }
                else
                {
                    targetToDmage[i].GetComponent<IEnemy>().TakeDamage(damage);
                }

            }
            else
            {
                targetToDmage[i].GetComponent<IPlayer>().HP -= damage;
            }


        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.attactPos.position, this.attactRange);
    }
}
