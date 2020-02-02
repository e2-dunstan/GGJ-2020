using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTool : MonoBehaviour
{
    public float despawnDistance = 100f;
    private Vector3 originalSpot = new Vector3(0, 0, 0);

    private void Start()
    {
        originalSpot = this.gameObject.transform.position;
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}
