using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemyMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 1f;
    private float jumpPower = 10f;
    private float jumpDelay = 0.8f;
    private bool jumpQueued = false;
    private float jumpTimer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private Transform player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        HandleJumpLogic();
        if (playerRB.position.x < rb.position.x)
        {
            horizontal = -1f;
        }
        else
        {
            horizontal = 1f;
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    // ChatGPT. "Enemy AI Design Usage", OpenAI, 11 Feb. 2026, https://chatgpt.com/share/698e42a5-c2a4-8013-8bee-feac664fc53d.
    // ------------
    void HandleJumpLogic()
    {
        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();

        // Detect player jump
        if (playerScript.JustJumped && !jumpQueued)
        {
            jumpQueued = true;
            jumpTimer = jumpDelay;
        }

        // Countdown
        if (jumpQueued)
        {
            jumpTimer -= Time.deltaTime;

            if (jumpTimer <= 0f)
            {
                if (IsGrounded())
                {
                    Jump();
                }
                jumpQueued = false;
            }
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        if (collision.gameObject.CompareTag("Lava"))
        {
            Destroy(gameObject);
        }
    }

    // ------------
}
