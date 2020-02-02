using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    bool alive = false;
    Material thisButtonMaterial;

    private void Start()
    {
        thisButtonMaterial = this.gameObject.GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        alive = GameManager.Instance.GetBodyState();
        if (alive)
        {
            thisButtonMaterial.color = Color.green;
        }
        else
        {
            thisButtonMaterial.color = Color.red;
        }
    }
}
