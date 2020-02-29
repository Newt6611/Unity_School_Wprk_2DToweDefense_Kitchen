using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class IEnemy : MonoBehaviour
{
    // Target Section
    protected bool isPlayerNear;
    [SerializeField] private float checkRange;
    [SerializeField] private Transform checkPos;
    [SerializeField] protected LayerMask playerLayer;


    [SerializeField] private float moveSpeed;

    // HP And HealthBar
    public RectTransform healthBarTransform;
    public Image healthBar;
    public int startHP;
    protected int HP;


    // Attack Section
    [SerializeField] protected float attackSpeed;
    private float attackSpeedBTWtime;

    // Effect Section
    public GameObject deadEffect;

    // Component Section
    protected IAttack Attack;
    protected Rigidbody2D rb;
    public Animator ani;

    // dropMoney
    [SerializeField] float dropMoney;
    [SerializeField] GameObject floatText;

    protected bool canAttack;
    void Start()
    {
        attackSpeedBTWtime = 0.5f;
        rb = GetComponent<Rigidbody2D>();
        isPlayerNear = false;
        HP = startHP;
        canAttack = true;
    }

    void FixedUpdate()
    {
        // DisplayHealthBar
        healthBar.fillAmount = (float)HP / startHP;
        CheckPlayerIsInsideRange();
        MoveStatMent();
        HpManager();
    }

    // Method Section

    protected void Move()
    {
        rb.velocity = Vector2.left * GetSpeed();
    }
    protected void StopMove()
    {
        rb.velocity = Vector2.zero;
    }

    protected void CheckPlayerIsInsideRange()
    {
        Collider2D target = Physics2D.OverlapCircle(checkPos.position, checkRange, playerLayer);
        if (target != null)
        {
            isPlayerNear = true;
            CharcterRotation(target.transform);
        }
        else
        {
            rb.rotation = 0f;
            isPlayerNear = false;
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.collider.tag == "Base")
        {
            HP = 0;
            target.collider.GetComponent<Base>().TakeDamage(10);
        }
        else
        {
            return;
        }
    }
    protected void MoveStatMent()
    {
        if (!isPlayerNear)
        {
            Move();
        }
        else if (isPlayerNear && canAttack)
        {
            StopMove();
            if (attackSpeedBTWtime <= 0f)
            {
                ani.SetTrigger("attack");
                attackSpeedBTWtime = attackSpeed;
            }
            else
            {
                attackSpeedBTWtime -= Time.deltaTime;
            }
        }
        else if (isPlayerNear && !canAttack)
        {
            StopMove();
        }
    }

    private void CharcterRotation(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 180f;
        rb.rotation = angle;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(checkPos.position, checkRange);
    }

    private void HpManager()
    {
        healthBarTransform.rotation = Quaternion.identity;
        if (HP <= 0f)
        {
            ShopSystem.TotalMoney += dropMoney;
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            ShowFloatText();
            Destroy(gameObject);
        }
    }

    private void ShowFloatText()
    {
        var t = Instantiate(floatText, transform.position, Quaternion.identity).GetComponentInChildren<TextMeshPro>();
        t.text = "+" + dropMoney.ToString();
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    // Getter Setter
    public float GetSpeed()
    {
        return moveSpeed;
    }
    public void SetSpeed(float _speed)
    {
        moveSpeed = _speed;
    }

}
