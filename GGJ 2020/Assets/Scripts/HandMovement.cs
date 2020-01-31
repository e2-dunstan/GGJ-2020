using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    private float startingHeight = 0.0f;
    private float horizontalMove = 0.0f;
    private float verticalMove = 0.0f;

    private float movementSpeed = 5.0f;

    public Transform itemTouching = null;

    public bool grabbing = false;

    // Start is called before the first frame update
    void Start()
    {
        startingHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        GrabInput();
        GetMovementInput();
        Movement();
    }

    private void GrabInput()
    {
        if (!grabbing)
        {
            if (Input.GetAxis("TriggerR1") > 0)
            {
                if (itemTouching)
                {
                    grabbing = true;
                    itemTouching.transform.parent = gameObject.transform;
                }
            }
        }
        else
        {
            if (Input.GetAxis("TriggerR1") == 0)
            {
                grabbing = false;
                itemTouching.transform.parent = null;
                itemTouching = null;
            }
        }
    }

    private void Movement()
    {
        Vector3 move = new Vector3(0, 0, 0);
        move.x = horizontalMove;
        move.z = verticalMove;        
        transform.Translate(move * movementSpeed * Time.deltaTime);

        Vector3 depthMove = transform.position;
        depthMove.y = startingHeight - Input.GetAxisRaw("TriggerL1");

        transform.position = depthMove;
    }

    private void GetMovementInput()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            itemTouching = other.transform;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == itemTouching)
        {
            itemTouching = null;
        }
    }
}
