using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatterManager : MonoBehaviour
{
    [SerializeField] GameObject splatter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewSplatter()
    {
        float xPos = Random.Range(0, Screen.width);
        float yPos = Random.Range(0, Screen.height);

        GameObject splat = Instantiate(splatter, new Vector3(xPos, yPos, 0), Quaternion.identity);
        splat.transform.parent = transform;
    }
}
