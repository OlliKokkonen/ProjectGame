using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{ 

    public GameManager powerUp;
    public int damage = 20;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Debug.Log("Enemy Hit");
            gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);

        }
    }


}
