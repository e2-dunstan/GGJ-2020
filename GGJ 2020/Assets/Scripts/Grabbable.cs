using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField] bool isTool = true;
    private LineRenderer lRenderer;
    private SpringJoint spring;

    public bool attached {private set; get;}

    // Start is called before the first frame update
    void Start()
    {
        attached = false;

        if (!isTool)
        {
            SetupUmbilical();
        }
    }

    private void SetupUmbilical()
    {
        attached = true;

        lRenderer = GetComponent<LineRenderer>();
        lRenderer.SetPosition(0, transform.position);
        Keyframe[] frames = new Keyframe[10];

        float frame = 0.0f;
        float min = 0.0f;
        float max = 0.1f;

        for (int i = 0; i < 10; i++)
        {
            float rand = UnityEngine.Random.Range(min, max);
            Keyframe key = new Keyframe(frame, rand);
            frame += 0.1f;
            frames[i] = key;
            min += 0.05f;
            max += 0.05f;
        }

        lRenderer.widthCurve = new AnimationCurve(frames);

        spring = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attached)
            UpdateLineRenderer();
    }

    private void UpdateLineRenderer()
    {
        for (int i = 1; i < lRenderer.positionCount; i++)
        {
            lRenderer.SetPosition(i, Vector3.Lerp(lRenderer.GetPosition(0), transform.position, 0.1f * i));
        }

        if (!spring)
        {
            attached = false;
            lRenderer.enabled = false;
        }        
    }
}
