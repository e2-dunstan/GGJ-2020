using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSecondCamera : MonoBehaviour
{
    private Transform ftwCamera;

    void Start()
    {
        ftwCamera = gameObject.transform.Find("FTW");
        ftwCamera.gameObject.GetComponent<FTW>().SetSecondCamera(this.gameObject);

    }
}
