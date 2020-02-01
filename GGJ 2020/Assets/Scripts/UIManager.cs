using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private BloodSplatterManager bloodSplatterManager;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bloodSplatterManager = GetComponent<BloodSplatterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewBloodSplatter()
    {
        bloodSplatterManager.NewSplatter();
    }
}
