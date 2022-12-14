using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] float movementup;
    [SerializeField] int speed = 10;
    [SerializeField] public bool isFacingRight;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 400.0f;
    [SerializeField] bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        movementup = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && isGrounded)
            jumpPressed = true;
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, movementup * speed);
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if ((movement < 0 && isFacingRight) || (movement > 0 && !isFacingRight))
            Flip();
        if (jumpPressed && isGrounded)
            Jump();
    }
    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        jumpPressed = false;
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

}
