using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaeManager : MonoBehaviour
{
    public static GaeManager instance;

    public enum BodyState
    {
        NEW = 0, CUTTING = 1, DISSECTING = 2, TAPING = 3, WIN = 4
    }
    public BodyState bodyState = BodyState.NEW;

    [HideInInspector] public bool wait = false;

    public Body currentBody { get; set; }


    private void Awake()
    {
        if (!instance) instance = this;
    }

    void Update()
    {
        if (wait) return;
        switch (bodyState)
        {
            case BodyState.NEW:
                wait = true;
                BodyManager.instance.BringOut();
                BodyManager.instance.BringIn();
                break;

            case BodyState.CUTTING:
                if (CuttingComplete()) bodyState++;
                break;

            case BodyState.DISSECTING:
                if (DissectionComplete()) bodyState++;
                break;

            case BodyState.TAPING:
                if (TapingComplete()) bodyState = 0;
                break;

            case BodyState.WIN:
                wait = true;
                BodyManager.instance.BringOut();
                Win();
                break;
        }
    }

    private bool CuttingComplete()
    {
        return false;
    }

    private bool DissectionComplete()
    {
        if (currentBody.complete) return true;
        //for(int i = 0; i < currentBody.partsToRemove.Count; i++)
        //{
        //    if (!currentBody.partsToRemove[i].removed) return false;
        //}
        return true;
    }

    private bool TapingComplete()
    {
        return false;
    }

    private void Win()
    {

    }

    public Body GetCurrentBody()
    {
        return currentBody;
    }
}