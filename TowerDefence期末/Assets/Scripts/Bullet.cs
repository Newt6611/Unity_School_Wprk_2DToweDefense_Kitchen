using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float aliveTime;

    void Update()
    {
        if (aliveTime <= 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            aliveTime -= Time.deltaTime;
        }
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        // Slipper And CockRoach Section
        if (gameObject.tag == "SlipperBullet")
        {
            if (target.tag == "CockRoach")
            {
                // Special Damage
                target.GetComponent<IEnemy>().TakeDamage(10);
            }
            else
            {
                // Normal Damage
                target.GetComponent<IEnemy>().TakeDamage(5);
            }
        }

        // Swatter Section
        if (gameObject.tag == "SwatterBullet")
        {
            if (target.tag == "Mosquito" || target.tag == "Fly")
            {
                target.GetComponent<IEnemy>().TakeDamage(10);
            }
            else
            {
                target.GetComponent<IEnemy>().TakeDamage(6);
            }
        }

        // Enemy Bullet Section
        if (gameObject.tag == "FlyBullet")
        {
            target.GetComponent<IPlayer>().HP -= 8;
        }
        else if (gameObject.tag == "MosquitoBullet")
        {
            target.GetComponent<IPlayer>().HP -= 6;
        }

        Destroy(gameObject);
    }
}
