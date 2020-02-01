using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodColliison : MonoBehaviour
{

    [SerializeField] private GameObject bloodPrefab;
    [SerializeField] private ParticleSystem particleSystem;
    public List<ParticleCollisionEvent> collisionEvents;

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
        if (other.tag != "Blood" && other.tag != "BloodParticle")
        {
            Instantiate(bloodPrefab, collisionEvents[0].intersection, Quaternion.identity);
        }
        else
        {
            other.gameObject.GetComponent<BloodSetUp>().IncreaseBlood();
        }
    }

}
