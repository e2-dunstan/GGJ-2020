using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    private float angle = 0;
    private Vector3 appliedRotation = new Vector3(0.01f, 0.05f, 0);

    void Start()
    {
        
    }

    void Update()
    {
        this.gameObject.transform.Rotate(appliedRotation);
    }
}
