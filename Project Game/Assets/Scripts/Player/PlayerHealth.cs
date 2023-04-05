using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead = false;

    public HealthBar healthBar;

    public Animator animator;
    public PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(20);
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            movement.activeMoveSpeed = 0f;
            isDead = true;
            animator.SetBool("IsDead", isDead);
            Destroy(gameObject, 3);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void GainHealth(int gainedhealth)
    {
        currentHealth += gainedhealth;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(currentHealth);


    }
}
