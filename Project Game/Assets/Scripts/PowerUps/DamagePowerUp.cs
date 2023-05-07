using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    public float multiplier = 1.4f;
    public float duration = 4f;

    Bullet active;
    [SerializeField] GameObject bullet;

    void Awake()
    {
        active = bullet.GetComponent<Bullet>(); 
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("PowerUp");

            active.extraDamage = true;
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        Debug.Log("Damage Power up picked up!");

        //Instantiate(pickupEffect, transform.position, transform.rotation);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        active.extraDamage = false;

        Destroy(gameObject);

        Debug.Log("Game Object Destroyed");
    }
}
