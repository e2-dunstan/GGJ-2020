using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCutManager : MonoBehaviour
{
    private List<GameObject> cutPoints = new List<GameObject>();
    [SerializeField] GameObject bloodParticle;
    [SerializeField] GameObject cutPointPrefab;

    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;

    [SerializeField] float numCutPoints = 15;
    // Start is called before the first frame update
    void Start()
    {
        SetupCutPoints();
    }

    private void SetupCutPoints()
    {
        for (int i = 0; i < numCutPoints; i++)
        {
            Vector3 newPos = Vector3.Lerp(startPos.position, endPos.position, i / numCutPoints);

            GameObject point = Instantiate(cutPointPrefab, newPos, Quaternion.identity);
            point.GetComponent<ChestCutPoint>().SetManager(this);
            point.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cut(Vector3 _pos)
    {
        GameObject blood = Instantiate(bloodParticle, _pos, Quaternion.identity);
        blood.transform.Rotate(-90, 0, 0);
        StartCoroutine("BloodFade", blood.GetComponent<ParticleSystem>());
        //Destroy(blood, 3);
    }

    IEnumerator BloodFade(ParticleSystem _blood)
    {
        ParticleSystem.EmissionModule em = _blood.emission;
        while (_blood)
        {
            ParticleSystem.MinMaxCurve r = em.rateOverTime;
            r.constantMax *= 0.9f;
            em.rateOverTime = r;

            if (em.rateOverTime.constantMax < 10)
            {
                _blood.Stop();
                Destroy(_blood, 3);
            }

            yield return new WaitForSeconds(.1f);
        }
    }
}
