using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    [SerializeField] int ID = 0;
    [SerializeField] Transform grabPos;

    private Rigidbody rbody;
    private Animator anim;

    private float startingHeight = 0.0f;
    private float horizontalMove = 0.0f;
    private float verticalMove = 0.0f;

    private float movementSpeed = 1.0f;
    private float acceleration = 1.0f;

    private Transform itemTouching = null;

    private bool grabbing = false;

    private string horizontalAxisString = "Horizontal";
    private string verticalAxisString = "Vertical";
    private string LTriggerAxisString = "TriggerL1";
    private string RTriggerAxisString = "TriggerR1";
    private string startButtonString = "Start1";

    private Vector3 spawnPos;

    private Vector3 min = new Vector3(18, 0, -3);
    private Vector3 max = new Vector3(21, 0, -1);

    private bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();        
        startingHeight = transform.position.y;
        spawnPos = transform.position;

        AssignStrings();

        //playing = false;
        //foreach (Transform child in transform)
        //{
        //    child.gameObject.SetActive(false);
        //}
    }    

    // Update is called once per frame
    void Update()
    {
        GetInput();
        GrabInput();
        GetMovementInput();
        Movement();
    }

    private void GetInput()
    {
        //if (Input.GetButtonDown(startButtonString))
        //{
        //    if (playing)
        //    {
        //        playing = false;
        //        foreach (Transform child in transform)
        //        {
        //            child.gameObject.SetActive(false);
        //        }
        //    }
        //    else
        //    {
        //        playing = true;
        //        gameObject.transform.position = spawnPos;

        //        foreach (Transform child in transform)
        //        {
        //            child.gameObject.SetActive(true);
        //        }
        //    }
        //}
    }

    private void GrabInput()
    {
        if (Input.GetAxis(RTriggerAxisString) > 0)
            anim.SetBool("Grab", true);

        if (anim.GetBool("Grab"))
        {
            if (Input.GetAxis(RTriggerAxisString) == 0)
                anim.SetBool("Grab", false);
        }

        if (!grabbing)
        {
            if (Input.GetAxis(RTriggerAxisString) > 0)
            {
                if (itemTouching)
                {
                    grabbing = true;
                    itemTouching.transform.parent = gameObject.transform;
                    itemTouching.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    itemTouching.gameObject.GetComponent<Grabbable>().SetIsGrabbed(true);
                    itemTouching.gameObject.GetComponent<Grabbable>().SetLastTouchedID(ID);
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
                    ResetGrabbedObject();
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
        move.x = horizontalMove * -10000000;
        move.z = verticalMove;
        transform.Translate(move * (movementSpeed * acceleration) * Time.deltaTime);

        Vector3 depthMove = transform.position;
        depthMove.y = startingHeight - Input.GetAxis(LTriggerAxisString);

        transform.position = depthMove;

        //Clamp position
        transform.position = ClampedPosition(transform.position);


        if (grabbing)
        {
            if (itemTouching)
            {
                itemTouching.gameObject.transform.position = grabPos.position;
            }
        }
    }

    private Vector3 ClampedPosition(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.z = Mathf.Clamp(pos.z, min.z, max.z);
        return pos;
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
                ResetGrabbedObject();
            }

            itemTouching = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HandMovement>())
        {
            ResetMovement();
            ResetGrabbedObject();
            float magnitude = 2f;
            Vector3 force = transform.position - collision.transform.position;
            force.Normalize();
            rbody.AddForce(force * magnitude, ForceMode.Impulse);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-force * magnitude, ForceMode.Impulse);
            AudioManager.instance.HandSlaps();
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
                startButtonString = "Start1";
                break;
            case 1:
                horizontalAxisString = "Horizontal2";
                verticalAxisString = "Vertical2";
                LTriggerAxisString = "TriggerL2";
                RTriggerAxisString = "TriggerR2";
                startButtonString = "Start2";
                break;
            case 2:
                horizontalAxisString = "Horizontal3";
                verticalAxisString = "Vertical3";
                LTriggerAxisString = "TriggerL3";
                RTriggerAxisString = "TriggerR3";
                startButtonString = "Start3";
                break;
            case 3:
                horizontalAxisString = "Horizontal4";
                verticalAxisString = "Vertical4";
                LTriggerAxisString = "TriggerL4";
                RTriggerAxisString = "TriggerR4";
                startButtonString = "Start4";
                break;
        }
    }

    private void ResetGrabbedObject()
    {
        if (itemTouching)
        {
            itemTouching.gameObject.GetComponent<Grabbable>().SetIsGrabbed(false);
            itemTouching.gameObject.GetComponent<Rigidbody>().useGravity = true;
            itemTouching.transform.parent = null;
            itemTouching = null;
        }
    }

    public void ResetMovement()
    {
        horizontalMove = 0.0f;
        verticalMove = 0.0f;
        acceleration = 1.0f;
    }
}
