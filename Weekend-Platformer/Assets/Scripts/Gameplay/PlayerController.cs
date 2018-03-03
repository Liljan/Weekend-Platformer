using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;

    // Ground
    public Transform groundCheckPoint;
    public LayerMask groundLayer;

    // Running
    public float speed = 1.0f;

    // Jumping
    private bool isGrounded = true;
    public float jumpImpulse = 1.0f;
    public float jumpForce = 1.0f;
    public float JUMP_TIME = 0.2f;
    //private float jumpTimer = 0.0f;
    public Vector2 groundDetectionSize;

    public uint JUMP_COUNT = 1;
    private uint jumpCounter;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        //isGrounded = false;
       // jumpTimer = 0.0f;
        jumpCounter = 0;
        //groundDetectionSize = new Vector2(0.5f, 0.09f);
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(speed * x, rb2d.velocity.y);
        SetFacingDirection(x);

        animator.SetFloat("Movement", Mathf.Abs(x));
    }

    private void SetFacingDirection(float xAxis)
    {
        if (xAxis <= -0.1f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (xAxis >= 0.1f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void Jumping()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.05f, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundDetectionSize, 0.0f, groundLayer);
        isGrounded &= rb2d.velocity.y <= 0.0f;

        if (isGrounded)
        {
            jumpCounter = 0;
            //jumpTimer = 0.0f;
        }

        if (Input.GetButtonDown("Jump") && rb2d.velocity.y >= 0.0f)
        {
            if (jumpCounter > JUMP_COUNT-1)
                return;

                jumpCounter++;
                rb2d.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
        }

       /* if (Input.GetButton("Jump") && jumpCounter < JUMP_COUNT)
        {
            if (jumpTimer > JUMP_TIME)
                return;

            if (rb2d.velocity.y < 0.0f)
                return;

            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            jumpTimer += Time.deltaTime;
        }
        */

        animator.SetBool("Grounded", isGrounded);
    }

    private void Update()
    {
        Movement();
        Jumping();
    }
}
