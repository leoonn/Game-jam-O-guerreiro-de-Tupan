﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayer : MonoBehaviour
{
    public Vector3 moveDirection;

    public const float maxDashTime = 1.0f;
    public float dashDistance = 10;
    public float dashStoppingSpeed = 0.1f;
    float currentDashTime = maxDashTime;
    float dashSpeed = 6;
    CharacterController controller;

    public float timeDash = 2f;
     float waitSeconds;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        waitSeconds = timeDash;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && waitSeconds <= 0) //Right mouse button
        {
            waitSeconds = timeDash;
            currentDashTime = 0;
        }
        else
        {
            waitSeconds -= Time.deltaTime;
        }
        if (currentDashTime < maxDashTime)
        {
            moveDirection = transform.forward * dashDistance;
            currentDashTime += dashStoppingSpeed;
        }
        else
        {
            moveDirection = Vector3.zero;
        }
       // controller.Move(moveDirection * Time.deltaTime * dashSpeed);
    }
}

