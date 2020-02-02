using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSecondCamera : MonoBehaviour
{
    [SerializeField]private GameObject ftwCamera;

    void Start()
    {
        ftwCamera.GetComponent<FTW>().SetSecondCamera(this.gameObject);

    }
}
