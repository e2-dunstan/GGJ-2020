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
            cutPoints.Add(point);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cut(Vector3 _pos, GameObject _cut)
    {
        GameObject blood = Instantiate(bloodParticle, _pos, Quaternion.identity);
        blood.transform.Rotate(-90, 0, 0);

        UIManager.instance.NewBloodSplatter();

        cutPoints.Remove(_cut);

        if (cutPoints.Count < 1)
        {
            StartCoroutine("FillScreenWithBlood");
        }
    }

    IEnumerator FillScreenWithBlood()
    {
        for (int i = 0; i < 20; i++)
        {
            UIManager.instance.NewBloodSplatter();
        }

        yield return new WaitForSeconds(0.5f);
        bodyboi.instance.FinishedCutting();
    }
}
