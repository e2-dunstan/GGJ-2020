using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TendonObject : MonoBehaviour
{
    private LineRenderer lRenderer;
    private SpringJoint spring;

    public bool attached { private set; get; }

    // Start is called before the first frame update
    void Start()
    {
        lRenderer = GetComponent<LineRenderer>();
        lRenderer.SetPosition(0, transform.position);

        spring = GetComponent<SpringJoint>();

        SetupUmbilical();
    }

    void Update()
    {
        if (attached)
            UpdateLineRenderer();
    }

    private void UpdateLineRenderer()
    {
        for (int i = 1; i < lRenderer.positionCount; i++)
        {
            if (lRenderer && spring)
            {
                lRenderer.SetPosition(i, Vector3.Lerp(spring.connectedBody.gameObject.transform.position, transform.position, 0.1f * i));
            }
            else
                Destroy(this.gameObject);
        }
    }

    private void SetupUmbilical()
    {
        attached = true;

        Keyframe[] frames = new Keyframe[10];

        float frame = 0.0f;
        float min = 0.06f;
        float max = 0.065f;

        for (int i = 0; i < 10; i++)
        {
            float rand = UnityEngine.Random.Range(min, max);
            Keyframe key = new Keyframe(frame, rand);
            frame += 0.1f;
            frames[i] = key;
            min -= 0.005f;
            max -= 0.005f;
        }

        lRenderer.widthCurve = new AnimationCurve(frames);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sharp")
            Destroy(this.gameObject);
    }
}
