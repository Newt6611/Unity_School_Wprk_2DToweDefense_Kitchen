using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : MonoBehaviour, IAttack
{
    [SerializeField] Transform shootPos;
    [SerializeField] GameObject bulletPre;
    [SerializeField] private float bulletSpeed;

    public void attack()
    {
        GameObject bullet = Instantiate(bulletPre, shootPos.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootPos.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
