using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    [SerializeField] int ID = 0;

    private Rigidbody rbody;

    private float startingHeight = 0.0f;
    private float horizontalMove = 0.0f;
    private float verticalMove = 0.0f;

    private float movementSpeed = 5.0f;
    private float acceleration = 1.0f;

    private Transform itemTouching = null;

    private bool grabbing = false;

    private string horizontalAxisString = "Horizontal";
    private string verticalAxisString = "Vertical";
    private string LTriggerAxisString = "TriggerL1";
    private string RTriggerAxisString = "TriggerR1";

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();        
        startingHeight = transform.position.y;

        AssignStrings();
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
            if (Input.GetAxis(RTriggerAxisString) > 0)
            {
                if (itemTouching)
                {
                    grabbing = true;
                    itemTouching.transform.parent = gameObject.transform;
                    itemTouching.gameObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
        else
        {
            if (Input.GetAxis(RTriggerAxisString) == 0)
            {
                grabbing = false;

                if (itemTouching)
                {
                    itemTouching.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    itemTouching.transform.parent = null;
                    itemTouching = null;
                }
            }
        }
    }

    private void Movement()
    {
        if (horizontalMove != 0 || verticalMove != 0)
        {            
            if (acceleration < 2.0f)
            {
                acceleration += 0.02f;
            }
        }
        else
        {
            if (acceleration > 1.0f)
            {
                acceleration -= 0.01f;
            }
        }

        Vector3 move = new Vector3(0, 0, 0);
        move.x = horizontalMove;
        move.z = verticalMove;        
        transform.Translate(move * (movementSpeed * acceleration) * Time.deltaTime);

        Vector3 depthMove = transform.position;
        depthMove.y = startingHeight - Input.GetAxis(LTriggerAxisString);

        transform.position = depthMove;

        
    }

    private void GetMovementInput()
    {
        horizontalMove = Input.GetAxis(horizontalAxisString);
        verticalMove = Input.GetAxis(verticalAxisString);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!grabbing)
        {
            if (other.GetComponent<Grabbable>())
            {
                itemTouching = other.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == itemTouching)
        {
            if (grabbing)
            {
                grabbing = false;
                itemTouching.transform.parent = null;
            }

            itemTouching = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HandMovement>())
        {
            ResetMovement();
            float magnitude = 5f;
            Vector3 force = transform.position - collision.transform.position;
            force.Normalize();
            rbody.AddForce(force * magnitude, ForceMode.Impulse);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-force * magnitude, ForceMode.Impulse);
        }
    }

    private void AssignStrings()
    {
        switch (ID)
        {
            case 0:
                horizontalAxisString = "Horizontal";
                verticalAxisString = "Vertical";
                LTriggerAxisString = "TriggerL1";
                RTriggerAxisString = "TriggerR1";
                break;
            case 1:
                horizontalAxisString = "Horizontal2";
                verticalAxisString = "Vertical2";
                LTriggerAxisString = "TriggerL2";
                RTriggerAxisString = "TriggerR2";
                break;
            case 2:
                horizontalAxisString = "Horizontal3";
                verticalAxisString = "Vertical3";
                LTriggerAxisString = "TriggerL3";
                RTriggerAxisString = "TriggerR3";
                break;
            case 3:
                horizontalAxisString = "Horizontal4";
                verticalAxisString = "Vertical4";
                LTriggerAxisString = "TriggerL4";
                RTriggerAxisString = "TriggerR4";
                break;
        }
    }

    public void ResetMovement()
    {
        horizontalMove = 0.0f;
        verticalMove = 0.0f;
        acceleration = 1.0f;
    }
}
