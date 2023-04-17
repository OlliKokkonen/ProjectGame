using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    public int destroyTime = 5;

    public bool extraDamage = false;

    void Update()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnCollisionEnter2D(Collision2D collsion)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        //gameObject.GetComponent<PlayerHealth>().TakeDamage(20);

        //Destroy(gameObject);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (extraDamage == true)
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(20);
            }

            if (extraDamage == false)
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(5);
            }

            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
