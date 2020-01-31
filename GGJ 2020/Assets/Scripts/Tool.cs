using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public GameObject tool;
    private Vector3 spawn;

    private void Start()
    {
        spawn = tool.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject newTool = Instantiate(tool, transform);
        newTool.transform.position = spawn;
    }
}
