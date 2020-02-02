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
                        GameManager.Instance.gameObject.GetComponent<bodyboi>().DoneWithThisOne();
                        break;
                    }
                case BodyLivingState.SAVED:
                    {
                        GameManager.Instance.GiveScore();
                        GameManager.Instance.gameObject.GetComponent<bodyboi>().DoneWithThisOne();
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

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Grabbable>().GetisTool() == true)
        {
            partsOutside++;
        }
        if (collision.gameObject.tag == "Foreign")
        {
            foreignsOutside++;
        }
    }

}
