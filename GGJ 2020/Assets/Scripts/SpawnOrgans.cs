using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrgans : MonoBehaviour
{
    private Vector3 minPos = new Vector3(-0.01f, -0.63f, -0.07f);
    private Vector3 maxPos = new Vector3(0.08f, 0.11f, -0.035f);

    public GameObject[] organs;
    public GameObject[] foreigns;

    private int numOrgans = 10;

    public void FillBody()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        const int chanceToForeign = 30;
        int currentForeign = 0;

        for (int i = 0; i < numOrgans; i++)
        {
            GameObject organ = Instantiate(organs[Random.Range(0, organs.Length - 1)], transform);
            organ.transform.localPosition = RandomPosition();

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
        foreign.transform.localPosition = RandomPosition();
        foreign.tag = "Foreign";
    }
}
