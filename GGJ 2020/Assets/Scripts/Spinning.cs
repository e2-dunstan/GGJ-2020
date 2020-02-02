using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    private float angle = 0;
    public Vector3 appliedRotation = new Vector3(1f, 5f, 0);

    void Start()
    {
        
    }

    void Update()
    {
        this.gameObject.transform.Rotate(appliedRotation * Time.deltaTime);
    }
}
