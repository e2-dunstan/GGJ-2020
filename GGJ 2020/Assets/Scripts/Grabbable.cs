using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField] bool isTool = true;

    private Rigidbody rbody;

    private bool isGrabbed = false;

    public bool isForeign = false;
    public bool attached {private set; get;}

    // Start is called before the first frame update
    void Start()
    {
        if (isTool)
            attached = false;
        else
            attached = true;

        rbody = GetComponent<Rigidbody>();
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
    }

    public bool GetisTool()
    {
        return isTool;
    }
}
