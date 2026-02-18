using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellowMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D playerRB;

    
    // Update is called once per frame
    void Update()
    {
        if (playerRB.position.x < rb.position.x)
        {
            horizontal = -1f;
        }
        else
        {
            horizontal = 1f;
        }
        if (playerRB.position.y < rb.position.y)
        {
            vertical = -1f;
        }
        else
        {
            vertical = 1f;
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Lava"))
        {
            Destroy(gameObject);
        }

    }

}
