using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public GameObject pickupEffect;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Health Power up picked up!");
            other.gameObject.GetComponent<PlayerHealth>().GainHealth(20);
            Destroy(gameObject);
        }
    }
}
