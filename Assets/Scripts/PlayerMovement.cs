﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] GameObject camera;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float L_E_A_N_MULTIPLIER;

    [SerializeField] LayerMask mask;

    Rigidbody rb;

    float xInput;
    float yInput;

    [SerializeField] bool doLean;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(camera == null)
        {
            //camera = Camera.main.gameObject;
        }
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");       
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
        Jump();
    }

    void Move()
    {
        Vector3 newVelocity = ((xInput * transform.right)+(yInput * transform.forward)) * moveSpeed;
        newVelocity.y = rb.velocity.y;
        rb.velocity = newVelocity;
    }

    void Rotate()
    {
        if(doLean)
        {
            Vector3 rotationValues = rb.velocity.normalized * L_E_A_N_MULTIPLIER;

            camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, Quaternion.Euler(rotationValues.z, camera.transform.eulerAngles.y, -rotationValues.x), 0.1f);
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
    
    void Jump()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y/2), transform.position.z), Vector3.down, .5f, mask))
            {
                rb.AddForce(new Vector3(rb.velocity.x, jumpForce, rb.velocity.y), ForceMode.VelocityChange);
            }
        }
    }
}
