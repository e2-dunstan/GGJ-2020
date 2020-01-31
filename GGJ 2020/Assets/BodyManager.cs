using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{

    public GameObject BodyPrefab;
    public Vector3 bodyPosition;
    private Vector3 bodyOffset = new Vector3(0, 0, 100);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BringIn()
    {
        GameObject newBod = Instantiate(BodyPrefab, (bodyPosition + bodyOffset), Quaternion.Euler(90, 0, 0), transform);
    }

    private void BringOut()
    {

    }
}
