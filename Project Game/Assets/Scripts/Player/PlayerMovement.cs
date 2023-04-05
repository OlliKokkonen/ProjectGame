using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;

    Vector2 movement;
    Vector2 mousePos;

    public float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    private float MovingDown = 0f;
    private float MovingUp = 0f;
    private float MovingLeft = 0f;
    private float MovingRight = 0f;

    SpriteRenderer spi;

    void Start()
    {
        activeMoveSpeed = moveSpeed;

        spi = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("SpeedDown", Mathf.Abs(MovingDown));
        animator.SetFloat("SpeedUp", Mathf.Abs(MovingUp));
        animator.SetFloat("SpeedLeft", Mathf.Abs(MovingLeft));
        animator.SetFloat("SpeedRight", Mathf.Abs(MovingRight));

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        dashSpeed = activeMoveSpeed * 2f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MovingUp = 1f;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            MovingUp = 0f;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            MovingDown = 1f;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            MovingDown = 0f;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            spi.flipX = false;
            MovingLeft = 1f;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            MovingLeft = 0f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            spi.flipX = true;
            MovingRight = 1f;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            MovingRight = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * activeMoveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
