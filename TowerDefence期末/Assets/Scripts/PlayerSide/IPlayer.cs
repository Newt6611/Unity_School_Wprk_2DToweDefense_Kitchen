using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IPlayer : MonoBehaviour
{
    // Dead Effect
    public GameObject deadEffect;

    // Check Enemy Section
    [SerializeField] private float checkRange;
    [SerializeField] private LayerMask enemyLayer;
    private bool isEnemyNear = false;

    // Attack Speed Section
    [SerializeField] protected float attackSpeed;
    private float attackSpeedBTWtime;

    // Mouse Position
    Vector2 mousePos;


    // Component Section
    protected Rigidbody2D rb;
    protected IAttack Attack;
    protected Animator ani;

    // Can Rotation
    protected bool canRotation;

    // HP
    public int StartHP;
    public int HP;
    public Image healthBar;
    // health Diplay
    public RectTransform healthDisplay;
    void Start()
    {
        ani = GetComponent<Animator>();
        HP = StartHP;
        attackSpeedBTWtime = 0.5f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CheckEnemyIsInsideRange();
        CharcterStatement();
        HPHandler();
    }



    // Method Section


    protected void CheckEnemyIsInsideRange()
    {
        Collider2D target = Physics2D.OverlapCircle(transform.position, checkRange, enemyLayer);
        if (target != null)
        {
            isEnemyNear = true;
            if (canRotation)
            {
                CharcterRotation(target.transform);
            }
        }
        else
        {
            rb.rotation = 0f;
            isEnemyNear = false;
        }
    }

    protected void CharcterRotation(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    void HPHandler()
    {
        healthDisplay.rotation = Quaternion.identity;
        healthBar.fillAmount = (float)HP / StartHP;
        if (HP <= 0)
        {
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    protected void CharcterStatement()
    {
        if (isEnemyNear)
        {
            if (attackSpeedBTWtime <= 0)
            {
                ani.SetTrigger("attack");
                attackSpeedBTWtime = attackSpeed;
            }
            else
            {
                attackSpeedBTWtime -= Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, checkRange);
    }
}
