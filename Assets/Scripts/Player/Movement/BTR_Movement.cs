using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BTR_Movement : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;

    [Header("Movement")] public float speed = 5;
    public float turnSpeed = 360;

    //Private Variables
    private BTR_InputManager inputManager;
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        inputManager = FindObjectOfType<BTR_InputManager>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(inputManager.movementVector.x, 0, inputManager.movementVector.y);

        //checks if there is an input of movement
        if (input != Vector3.zero)
        {
            playerAnimator.SetFloat("Speed", 1);
            //a matrix which gives the rotation of it to 45 degrees
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            // multiplies the vector with the matrix to rotate the movements 45 degrees
            var skewedInput = matrix.MultiplyPoint3x4(input);

            var relative = (transform.position + skewedInput) - transform.position;

            //  always moves foward
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            //turns to where it wants to go towards
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
        else
        {
            playerAnimator.SetFloat("Speed", 0);
        } 

        //moves the player to the inputed values
        rb.MovePosition(transform.position + transform.forward * input.normalized.magnitude * speed);
    }
}
