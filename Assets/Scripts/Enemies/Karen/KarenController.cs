﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarenController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 5f;
    private GameObject player;
    private Rigidbody2D rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(((player.transform.position - rb.transform.position).normalized * speed).x, rb.velocity.y);
    }
}