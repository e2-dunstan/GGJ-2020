using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public GameObject tool;
    private Vector3 spawn;

    private void Start()
    {
        spawn = transform.GetChild(0).position;
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            GameObject newTool = Instantiate(tool, transform);
            newTool.transform.position = spawn;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains(tool.name))
        {
            GameObject newTool = Instantiate(tool, transform);
            newTool.transform.position = spawn;
        }
    }
}
