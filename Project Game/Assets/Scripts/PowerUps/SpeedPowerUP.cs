using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUP : MonoBehaviour
{
    public GameObject pickupEffect;

    public float multiplier = 1.5f;
    public float duration = 4f;
    
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
        Debug.Log("Speed Power up picked up!");

        //Instantiate(pickupEffect, transform.position, transform.rotation);

        PlayerMovement speed = player.GetComponent<PlayerMovement>();
        speed.activeMoveSpeed *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        speed.activeMoveSpeed /= multiplier;

        Destroy(gameObject);

        Debug.Log("Game Object Destroyed");
    }
}
