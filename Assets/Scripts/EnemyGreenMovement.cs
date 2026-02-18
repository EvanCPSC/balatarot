using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreenMovement : MonoBehaviour
{
    private float horizontal = -1f;
    private float speed = 4f;
    [SerializeField] private Rigidbody2D rb;

    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Lava"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground"))
        {
            horizontal = -1 * horizontal;
        }
    }
}
