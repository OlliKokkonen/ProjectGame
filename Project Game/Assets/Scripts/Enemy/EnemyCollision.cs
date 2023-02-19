using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("PlayerBullet"))
        //{
            //Debug.Log("Enemy Hit");
            //gameObject.GetComponent<EnemyHealth>().TakeDamage(20);
        //}
    }
}
