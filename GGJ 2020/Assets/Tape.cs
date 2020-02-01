using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tape : MonoBehaviour
{
    public GameObject linePrefab;
    private LineRenderer line;
    private Grabbable grabbable;

    private bool drawing = false;
    private Vector3[] drawStartEnd = new Vector3[2];

    private void Awake()
    {
        grabbable = GetComponent<Grabbable>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (grabbable.attached && collision.gameObject.tag == "Tape-able")
        {
            drawing = true;
            drawStartEnd[0] = collision.GetContact(0).point;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (drawing && grabbable.attached && collision.gameObject.tag == "Tape-able")
        {
            drawStartEnd[1] = collision.GetContact(0).point;

            if (!line.gameObject.activeInHierarchy || line == null)
            {
                line = Instantiate(linePrefab).GetComponent<LineRenderer>();
            }
            line.SetPositions(drawStartEnd);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (drawing && collision.gameObject.tag == "Tape-able")
        {
            drawing = false;
            line = null;
        }
    }
}
