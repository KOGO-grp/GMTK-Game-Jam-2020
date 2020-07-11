﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private bool isJumping = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float jumpValue = Input.GetAxis("Jump");
        if(!isJumping && jumpValue > 0.5f)
        {
            rb.AddForce(transform.up * 150.0f);
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(2.0f, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isJumping = false;
    }
}
