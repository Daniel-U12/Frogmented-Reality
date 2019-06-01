﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float initialVelocity;
    public float gravityScale;

    private float target;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position.y;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y - target > 0)
        {
            rb.gravityScale = gravityScale;
        } else {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0f, 0f);
        }

        Debug.Log(transform.position.y - target);
            //float newPosition = Mathf.SmoothDamp(transform.position.y, target, ref velocity, transitionDuration);
            //velocity += acceleration * Time.deltaTime;
            //transform.position = new Vector3(transform.position.x, transform.position.y + velocity * Time.deltaTime, transform.position.z);
    }

    public void MoveDown(float distance)
    {
        rb.velocity = new Vector2(0f, initialVelocity);
        target -= distance;
    }
}
