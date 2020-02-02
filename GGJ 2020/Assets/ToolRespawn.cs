using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolRespawn : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sharp")
        {
            if (other.gameObject.GetComponent<Grabbable>() == null)
            {
                return;
            }
            else
            {
                other.gameObject.GetComponent<Grabbable>().ResetPosition();
            }
        }
        
    }

}
