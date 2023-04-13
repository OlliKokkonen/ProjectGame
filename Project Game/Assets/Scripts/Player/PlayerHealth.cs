using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public static int remainingHealth;
    public bool isHit = false;
    public bool isDead = false;

    public static bool firstLevelCleared = false;

    public float invicibilityFrames;
    public float duration = 2f;

    public HealthBar healthBar;

    public Animator animator;
    public PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        if (firstLevelCleared == false)
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        if (firstLevelCleared == true)
        {
            currentHealth = remainingHealth;
            healthBar.SetHealth(currentHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(20);
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            remainingHealth = currentHealth;
            firstLevelCleared = true;
        }

        if (invicibilityFrames >= 0)
        {
            invicibilityFrames -= Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        if (invicibilityFrames <= 0)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                movement.activeMoveSpeed = 0f;
                firstLevelCleared = false;
                isDead = true;
                animator.SetBool("IsDead", isDead);

                FindObjectOfType<AudioManager>().Play("Player Death");

                Destroy(gameObject, 3);
                FindObjectOfType<GameManager>().EndGame();
            }

            StartCoroutine(HitEffect());
            invicibilityFrames = 2f;
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

    IEnumerator HitEffect()
    {
        isHit = true;
        animator.SetBool("IsHit", isHit);

        yield return new WaitForSeconds(duration);

        isHit = false;
        animator.SetBool("IsHit", isHit);
    }

    public void Reset()
    {
        Debug.Log("Reset Function Called");
        firstLevelCleared = false;
    }
}
