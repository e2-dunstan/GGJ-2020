using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private LineRenderer lRenderer;
    private SpringJoint spring;

    private bool attached = true;

    // Start is called before the first frame update
    void Start()
    {
        lRenderer = GetComponent<LineRenderer>();
        lRenderer.SetPosition(0, transform.position);

        spring = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attached)
            UpdateLineRenderer();
    }

    private void UpdateLineRenderer()
    {
        lRenderer.SetPosition(1, transform.position);

        if (!spring)
        {
            attached = false;
            lRenderer.enabled = false;
        }        
    }
}
