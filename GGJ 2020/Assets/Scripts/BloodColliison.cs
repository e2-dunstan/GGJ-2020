using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodColliison : MonoBehaviour
{

    [SerializeField] private GameObject bloodPrefab;
    [SerializeField] private ParticleSystem particleSystem;

    public List<ParticleCollisionEvent> collisionEvents;
    private Vector3 objectRotation = new Vector3(-90, 0, 0);
    private Vector3 rot = new Vector3(0, 0, 0);
    

    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = particleSystem.GetCollisionEvents(other, collisionEvents);

        if (other.tag != "Blood" && other.tag != "BloodParticle" && other.tag != "Sharp")
        {
            if (!other.gameObject.GetComponent<Grabbable>())
            {
                GameObject obj = Instantiate(bloodPrefab, collisionEvents[0].intersection, Quaternion.identity);
                int y = Random.Range(-360, 360);
                rot.y = y;
                obj.transform.Rotate(rot);
            }
        }
        else
        {
            other.gameObject.GetComponent<BloodSetUp>().IncreaseBlood();
        }
    }

}
