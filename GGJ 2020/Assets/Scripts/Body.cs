using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public enum BodyLivingState
    {
        ALIVE, DEAD, SAVED
    }

    public BodyLivingState bodyState;

    public int partsInside;
    public int partsOutside;
    public bool cuttingComplete;
    public bool filled;
    private int foreignsInside;
    private int foreignsOutside;
    
    private void Start()
    {
        GameManager.Instance.SetCurrentBody(this.gameObject);
    }

    private void Update()
    {
        if (!filled)
        { return; }
        else
        {
            switch (bodyState)
            {
                case BodyLivingState.ALIVE:
                    {
                        if (partsOutside == partsInside)
                        {
                            bodyState = BodyLivingState.DEAD;
                        }
                        if (foreignsOutside == foreignsInside)
                        {
                            bodyState = BodyLivingState.SAVED;
                        }
                        break;
                    }
                case BodyLivingState.DEAD:
                    {

                        break;
                    }
                case BodyLivingState.SAVED:
                    {
                        //GameManager.Instance.GiveScore();
                        if (foreignsOutside == foreignsInside)
                        {
                            bodyState = BodyLivingState.SAVED;
                        }
                        //GameManager.Instance.gameObject.GetComponent<bodyboi>().DoneWithThisOne();
                        break;
                    }
            }
        }
    }

    public void SetPartsInside(int _amount, int _foreignAmount)
    {
        partsInside = _amount;
        foreignsInside = _foreignAmount;
        filled = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<Grabbable>() == null)
        {
            return;
        }
        if (collider.gameObject.GetComponent<Grabbable>().GetisTool() == false)
        {
            partsOutside++;
        }
        if (collider.gameObject.tag == "Foreign")
        {
            foreignsOutside++;
        }
    }

}
