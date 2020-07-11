﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform objectTransform;
    [SerializeField] private float smoothTime = 0f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Vector3 cameraLocation = new Vector3(0, 1, -10);
    // private float deltaX;

    void Start()
    {
        objectTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        // deltaX = transform.position.x - objectTransform.position.x;
        //transform.position = Vector3.SmoothDamp(objectTransform.position.x + deltaX, transform.position.y, transform.position.z);
        Vector3 targetPosition = objectTransform.TransformPoint(cameraLocation);
        // targetPosition.y = transform.position.y;
        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
