using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    float moveForce = 2;
    SpriteRenderer spr;
    float jumpForce = 5;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleAttack();
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void HandleMovement()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        rb.AddForce(horizontalAxis * moveForce * transform.right,
          ForceMode2D.Force);

        var IsWalking = rb.velocity.magnitude > 0.01f;
        animator.SetBool("IsWalking", IsWalking);

        bool right = horizontalAxis > 0 && !facingRight;
        bool left = horizontalAxis < 0 && facingRight;

        if (right)
            Flip();
        if (left)
            Flip();
    }

    private void Flip()
    {
        Vector3 currentScale = rb.transform.localScale;
        currentScale.x *= -1;
        rb.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
