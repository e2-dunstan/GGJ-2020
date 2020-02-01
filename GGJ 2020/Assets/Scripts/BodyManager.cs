using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    public static BodyManager instance;

    public Body[] bodies;

    public GameObject BodyPrefab;
    public Vector3 bodyPosition;
    private Vector3 bodyOffset = new Vector3(0, 0, 100);

    public AnimationCurve animCurve;


    private void Awake()
    {
        if (!instance) instance = this;
    }

    public void BringIn()
    {
        GaeManager.instance.currentBody.complete = true;
        GaeManager.instance.currentBody = GetNew();
        if (GaeManager.instance.currentBody == null)
        {
            GaeManager.instance.bodyState = GaeManager.BodyState.WIN;
            return;
        }

        GaeManager.instance.bodyState = GaeManager.BodyState.CUTTING;

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

        GaeManager.instance.wait = false;
    }

    public void BringOut()
    {

    }

    private IEnumerator BringOutCoroutine(Transform bod)
    {
        Vector3 start = bodyPosition;
        Vector3 end = bodyPosition - bodyOffset;

        bod.position = start;
        for (float t = 0.0001f; t < 1.0f; t += Time.deltaTime)
        {
            bod.position = start + ((end - start) * animCurve.Evaluate(t / 1.0f));
            yield return null;
        }
        bod.position = end;
    }

    private Body GetNew()
    {
        for(int i = 0; i < bodies.Length; i++)
        {
            if (!bodies[i].complete) return bodies[i];
        }
        return null;
    }
}
