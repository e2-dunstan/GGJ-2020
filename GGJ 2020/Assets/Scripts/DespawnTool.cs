using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTool : MonoBehaviour
{
    public float despawnDistance = 100f;

    void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}
