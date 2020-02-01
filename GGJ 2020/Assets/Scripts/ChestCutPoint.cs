using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCutPoint : MonoBehaviour
{
    [SerializeField] ChestCutManager cutManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Grabbable>())
        {
            cutManager.Cut(transform.position);
        }
    }

    public void SetManager(ChestCutManager _m)
    {
        cutManager = _m;
    }
}
