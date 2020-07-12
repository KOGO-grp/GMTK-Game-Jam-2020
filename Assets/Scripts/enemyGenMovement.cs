﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemyGenMovement : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float smoothTime = 0f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 cameraLocation = new Vector3(0, 15, -10);
    // private float deltaX;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        // deltaX = transform.position.x - objectTransform.position.x;
        //transform.position = Vector3.SmoothDamp(objectTransform.position.x + deltaX, transform.position.y, transform.position.z);
        Vector3 targetPosition = player.TransformPoint(cameraLocation);
        targetPosition.y *= 0.2f;
        targetPosition.x += 15.0f;
        // targetPosition.y = transform.position.y;
        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
