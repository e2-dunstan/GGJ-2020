using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [System.Serializable]
    public class Part
    {
        public Grabbable obj;
        [HideInInspector] public bool removed = false;
    }
    [HideInInspector] public List<Part> partsToRemove;
    [HideInInspector] public bool complete = false;

    [HideInInspector] public bool initialised = false;

    private void Update()
    {
        if (!initialised) return;

        for(int i = 0; i < partsToRemove.Count; i++)
        {
            if (!partsToRemove[i].obj.attached)
            {
                partsToRemove[i].removed = true;
                complete = true;
            }
            else
            {
                complete = false;
            }
        }
    }
}
