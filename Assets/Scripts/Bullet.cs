﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isCar = false;
    [SerializeField] private float speed = -20f;
    private Rigidbody2D rb;
    // private float dist;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(Kill());
    }
    void FixedUpdate()
    {
        // dist = Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        rb.velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Health>().Die();
        }
        if(collision.gameObject.tag == "obstacle")
        {
            if (collision.gameObject.GetComponent<FireController>() != null)
            {
                collision.gameObject.GetComponent<FireController>().Die();
            }
            else if (collision.gameObject.GetComponent<SpikesController>() != null && isCar)
            {
                collision.gameObject.GetComponent<SpikesController>().Die();
            }

        }
        
    }
    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
