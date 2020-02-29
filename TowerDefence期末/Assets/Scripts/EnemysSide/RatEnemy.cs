using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemy : IEnemy
{
    [SerializeField] private float checkDrugRange;
    [SerializeField] private LayerMask drugLayer;
    private Transform drugPos = null;
    private float backSpeed;
    void Awake()
    {
        Attack = GetComponent<MelleeAttack>();
    }

    void Update()
    {
        Collider2D drug = Physics2D.OverlapCircle(transform.position, checkDrugRange, drugLayer);
        if (drug != null)
        {
            drugPos = drug.GetComponent<Transform>();
            isPlayerNear = true;
            canAttack = false;
        }
        else
        {
            return;
        }

        if (drugPos != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, drugPos.position, GetSpeed() * 2 * Time.deltaTime);
        }
        else
        {
            isPlayerNear = false;
            canAttack = true;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Drug")
        {
            StopMove();
            SetSpeed(0);
            drugPos = null;
            Destroy(target.gameObject);
            // set eat tigger
            ani.SetTrigger("eat");
        }
        else if (target.tag == "Base")
        {
            target.GetComponent<Base>().TakeDamage(10);
            TakeDamage(1000);
        }
    }

    void Dead()
    {
        HP = 0;
    }
    void OnDrawGizmos()
    {
        // Check Durg Size Range
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, checkDrugRange);

    }
}
