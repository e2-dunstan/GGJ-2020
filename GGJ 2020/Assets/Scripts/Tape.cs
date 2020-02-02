using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tape : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject clothPrefab; 
    private LineRenderer line = null;
    private Grabbable grabbable;

    private bool drawing = false;
    private Vector3[] drawStartEnd = new Vector3[2];

    public LayerMask tapeableLayer;
    public float chestHeight = 0.1f;

    private void Awake()
    {
        grabbable = GetComponent<Grabbable>();
    }

    private void Update()
    {
        if (Input.GetAxis("Submit") != 0 && grabbable.GetIsGrabbed())
        {
            if (!drawing)
            {
                if (line == null || !line.gameObject.activeInHierarchy)
                {
                    line = Instantiate(linePrefab, null).GetComponent<LineRenderer>();
                }
                drawStartEnd[0] = GetPosition();
            }
            drawStartEnd[1] = GetPosition();

            line.SetPositions(drawStartEnd);

            drawing = true;
        }
        else if (!grabbable.GetIsGrabbed() || (drawing && Input.GetAxis("Submit") == 0))
        {
            if (line)
            CreateCloth(line);
            line = null;
            drawing = false;
        }
    }

    private void CreateCloth(LineRenderer line)
    {
        Vector3 pos = (drawStartEnd[0] + drawStartEnd[1]) / 2;
        float angle = Mathf.Atan2(drawStartEnd[1].y - drawStartEnd[0].y, drawStartEnd[1].z - drawStartEnd[0].z) * Mathf.Rad2Deg;
        GameObject cloth = Instantiate(clothPrefab, pos, Quaternion.Euler(0, angle, 0), transform);
        Destroy(line); 
    }

    private Vector3 GetPosition()
    {
        RaycastHit hit;
        Vector3 origin = transform.position + new Vector3(0, 3, 0);
        if (Physics.Raycast(origin, Vector3.down, out hit, 10))
        {
            return new Vector3(hit.point.x, chestHeight, hit.point.z);// + new Vector3(0, 0.1f, 0);
        }
        else
        {
            Debug.LogWarning("nah mate");
            return Vector3.zero;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other.gameObject.tag);
    //    if (grabbable.GetIsGrabbed() && other.gameObject.tag == "Tape-able")
    //    {
    //        drawing = true;

    //        RaycastHit hit;
    //        Vector3 origin = transform.position + new Vector3(0, 3, 0);
    //        if (Physics.Raycast(origin, Vector3.down, out hit, 10))
    //        {
    //            if (hit.transform.CompareTag(other.gameObject.tag))
    //            {
    //                drawStartEnd[0] = hit.point + new Vector3(0, 0.1f, 0);
    //                drawStartEnd[1] = hit.point + new Vector3(0, 0.1f, 0);

    //                if (line == null || !line.gameObject.activeInHierarchy)
    //                {
    //                    line = Instantiate(linePrefab, null).GetComponent<LineRenderer>();
    //                }
    //            }
    //        }

    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if (drawing && other.gameObject.tag == "Tape-able")
    //    {
    //        RaycastHit hit;
    //        Vector3 origin = transform.position + new Vector3(0, 3, 0);
    //        if (Physics.Raycast(origin, Vector3.down, out hit, 10))
    //        {
    //            if (hit.transform.CompareTag(other.gameObject.tag) && line)
    //            {
    //                drawStartEnd[1] = hit.point + new Vector3(0, 0.1f, 0);

    //                line.SetPositions(drawStartEnd);
    //            }
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if ((drawing && other.gameObject.tag == "Tape-able")
    //        || !grabbable.GetIsGrabbed())
    //    {
    //        drawing = false;
    //        line = null;
    //    }
    //}
}
