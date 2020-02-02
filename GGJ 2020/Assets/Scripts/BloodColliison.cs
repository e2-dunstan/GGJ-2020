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

        StartCoroutine("BloodFade", GetComponent<ParticleSystem>());
    }

    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = particleSystem.GetCollisionEvents(other, collisionEvents);

        if (other.tag == "Surface")
        {
            GameObject obj = Instantiate(bloodPrefab, collisionEvents[0].intersection, Quaternion.identity);
            int y = Random.Range(-360, 360);
            rot.y = y;
            obj.transform.Rotate(rot);
        }
        else if (other.gameObject.GetComponent<BloodSetUp>())
        {
            other.gameObject.GetComponent<BloodSetUp>().IncreaseBlood();
        }
    }

    IEnumerator BloodFade(ParticleSystem _blood)
    {
        ParticleSystem.EmissionModule em = _blood.emission;
        while (_blood)
        {
            ParticleSystem.MinMaxCurve r = em.rateOverTime;
            r.constantMax *= 0.95f;
            em.rateOverTime = r;

            if (em.rateOverTime.constantMax < 10)
            {
                _blood.Stop();
                Destroy(_blood.gameObject, 3);
            }

            yield return new WaitForSeconds(.1f);
        }
    }

}
