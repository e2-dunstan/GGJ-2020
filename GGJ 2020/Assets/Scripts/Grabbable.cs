﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField] bool isTool = true;

    private int lastTouchedID = 0;

    private Rigidbody rbody;

    private bool isGrabbed = false;

    public bool isForeign = false;
    public bool attached {private set; get;}


    private SphereCollider sphereCollider;
    private CapsuleCollider capsuleCollider;
    private BoxCollider boxCollider;

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.gameObject.transform.position;
        if (isTool)
            attached = false;
        else
            attached = true;

        rbody = GetComponent<Rigidbody>();

        if (GetComponent<SphereCollider>())
        {
            sphereCollider = GetComponent<SphereCollider>();
        }
        else if (GetComponent<CapsuleCollider>())
        {
            capsuleCollider = GetComponent<CapsuleCollider>();
        }
        else if (GetComponent<BoxCollider>())
        {
            boxCollider = GetComponent<BoxCollider>();
        }
    }    

    // Update is called once per frame
    void Update()
    {

    }

    public bool GetIsGrabbed()
    {
        return isGrabbed;
    }

    public void SetIsGrabbed(bool _grab)
    {
        isGrabbed = _grab;

        if (isGrabbed)
        {
            if (sphereCollider)
                sphereCollider.enabled = false;
            if (capsuleCollider)
                capsuleCollider.enabled = false;
            if (boxCollider)
                boxCollider.enabled = false;
        }
        else
        {
            if (sphereCollider)
                sphereCollider.enabled = true;
            if (capsuleCollider)
                capsuleCollider.enabled = true;
            if (boxCollider)
                boxCollider.enabled = true;
        }
    }

    public void SetLastTouchedID(int _id)
    {
        lastTouchedID = _id;
    }

    public int GetLastTouchedID()
    {
        return lastTouchedID;
    }

    public bool GetisTool()
    {
        return isTool;
    }

    public void ResetPosition()
    {
        this.transform.position = initialPosition;
    }
}
