using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TendonSpawner : MonoBehaviour
{
    [SerializeField] GameObject organ;
    [SerializeField] GameObject tendonPrefab;
    [SerializeField] int maxTendons = 4;

    // Start is called before the first frame update
    void Start()
    {
        SetupTendons();
    }

    private void SetupTendons()
    {
        int rand = UnityEngine.Random.Range(1, maxTendons);

        float spawnOffset = 0.2f;

        for (int i = 0; i < rand; i++)
        {
            Vector3 newPos = transform.position;
            newPos.x += UnityEngine.Random.Range(-spawnOffset, spawnOffset);
            newPos.z += UnityEngine.Random.Range(-spawnOffset, spawnOffset);
            GameObject tendy = Instantiate(tendonPrefab, newPos, Quaternion.identity);
            tendy.GetComponent<SpringJoint>().connectedBody = organ.GetComponent<Rigidbody>();
            tendy.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
