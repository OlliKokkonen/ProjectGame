using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    public int booster = 30;
    public float duration = 8f;

    //GameManager power;
    EnemyCollision power;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("PowerUp");
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        Debug.Log("Damage Power up picked up!");

        //Instantiate(pickupEffect, transform.position, transform.rotation);

        power = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyCollision>();
        //power = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        power.damage = 50;
        //power.enemyDamage = 50;
        Debug.Log("Damage increased");

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        power.damage = 20;
        //power.enemyDamage = 20;
        Debug.Log("Damage decreased");

        Destroy(gameObject);

        Debug.Log("Game Object Destroyed");
    }
}
