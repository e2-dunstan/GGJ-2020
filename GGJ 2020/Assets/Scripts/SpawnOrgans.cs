using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrgans : MonoBehaviour
{
    public Vector3 minPos;
    public Vector3 maxPos;

    public GameObject[] organs;
    public GameObject[] foreigns;

    private int numOrgans = 10;

    private Body body;

    void Start()
    {
        body = GetComponentInParent<Body>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        const int chanceToForeign = 30;
        int currentForeign = 0;

        for (int i = 0; i < numOrgans; i++)
        {
            GameObject organ = Instantiate(organs[Random.Range(0, organs.Length - 1)], transform);
            organ.transform.position = RandomPosition();

            if (Random.Range(0, 100) < chanceToForeign)
            {
                AddForeign();
                currentForeign++;
            }
            yield return null;
        }
        if (currentForeign <= 0)
        {
            AddForeign();
        }
    }

    private Vector3 RandomPosition()
    {
        float x = Random.Range(minPos.x, maxPos.x);
        float y = Random.Range(minPos.y, maxPos.y);
        float z = Random.Range(minPos.z, maxPos.z);

        return new Vector3(x, y, z);
    }

    private void AddForeign()
    {
        GameObject foreign = Instantiate(foreigns[Random.Range(0, foreigns.Length - 1)], transform);
        foreign.transform.position = RandomPosition();
        Body.Part newPart = new Body.Part();
        newPart.obj = foreign.GetComponent<Grabbable>();
        body.partsToRemove.Add(newPart);
    }
}
