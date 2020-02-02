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
        if (other.gameObject.tag == "Sharp")
        {
            cutManager.Cut(transform.position, gameObject);
            this.gameObject.SetActive(false);
        }
    }

    public void SetManager(ChestCutManager _m)
    {
        cutManager = _m;
    }
}
