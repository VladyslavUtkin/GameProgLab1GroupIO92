using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float moveThrust = 0.01f;
    [SerializeField] float jumpThrust = 0.01f;

    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var velocity = rb2d.velocity;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb2d.velocity = new Vector2(velocity.x, jumpThrust);
        }
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");

        rb2d.velocity = new Vector2(moveThrust * horizontal, rb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
