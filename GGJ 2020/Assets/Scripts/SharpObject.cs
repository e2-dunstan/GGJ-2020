using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpObject : MonoBehaviour
{
    [SerializeField] GameObject bloodPrefab;
    [SerializeField] Transform bladePoint;

    private float bloodSpawnDelay = 1.0f;
    private float bloodSpawnTimer = 0.0f;
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned)
        {
            bloodSpawnTimer += Time.deltaTime;

            if (bloodSpawnTimer > bloodSpawnDelay)
            {
                bloodSpawnTimer = 0.0f;
                spawned = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!spawned)
        {
            if (other.tag != "Surface" && other.tag != "Sharp" && other.gameObject != gameObject)
            {
                spawned = true;
                GameObject blood = Instantiate(bloodPrefab, bladePoint.position, Quaternion.identity);
                blood.transform.parent = other.gameObject.transform;
                UIManager.instance.NewBloodSplatter();

                if (other.GetComponent<HandMovement>())
                    AudioManager.instance.OuchNoise();
            }
        }
    }

}
