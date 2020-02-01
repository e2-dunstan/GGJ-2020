using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRagdoll : MonoBehaviour
{
    public GameObject LeftLeg;
    public GameObject RightLeg;

    void Start()
    {
        LeftLeg = GameObject.Find("mixamorig1:LeftLeg");
        RightLeg = GameObject.Find("mixamorig1:RightLeg");
    }
   
         
   

    // Update is called once per frame
    void Update()
    {
       if (Input.GetAxisRaw("Fire1") != 0)
        {
            LeftLeg.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -25));
            RightLeg.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -25));
        }

    }
}
