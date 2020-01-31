using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    public GameObject BodyPrefab;
    public Vector3 bodyPosition;
    private Vector3 bodyOffset = new Vector3(0, 0, 100);

    public AnimationCurve animCurve;


    private void BringIn()
    {
        GameObject newBod = Instantiate(BodyPrefab, (bodyPosition + bodyOffset), Quaternion.Euler(90, 0, 0), transform);
        StartCoroutine(BringInCoroutine(newBod.transform));
    }

    private IEnumerator BringInCoroutine(Transform bod)
    {
        Vector3 start = bodyPosition + bodyOffset;
        Vector3 end = bodyPosition;

        bod.position = start;
        for(float t = 0.0001f; t < 1.0f; t += Time.deltaTime)
        {
            bod.position = start + ((end - start) * animCurve.Evaluate(t / 1.0f));
            yield return null;
        }
        bod.position = end;
    }

    private void BringOut()
    {

    }
}
