using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 6f;
    private float jumpingPower = 8f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private int currScene;
    // From ChatGPT, used in assignment 1
    // ------------
    public bool JustJumped { get; private set; }
    // ------------

    // Update is called once per frame
    void Update()
    {
        // bendux. "2D Player Movement in Unity", YouTube, 3 Feb. 2022, https://youtu.be/K1xZ-rycYY8?si=yGmhRzQeFpW8al_N.
        // ------------
        horizontal = Input.GetAxisRaw("Horizontal");
        JustJumped = false;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            JustJumped = true;
        }
        // ------------
        // from scene manager
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
            Debug.Log("Game is exiting");
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Lava") || collision.gameObject.CompareTag("Spike"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(currScene);
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            currScene = (currScene + 1) % 17;
            UnityEngine.SceneManagement.SceneManager.LoadScene(currScene);
        }
    }
}
