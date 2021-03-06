﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyboi : MonoBehaviour
{
    public static bodyboi instance;
    [SerializeField] private Vector3 bodySpawnPoint;

    private Rigidbody boiRbody;

    public enum BodyState
    {
        NEW = 0, CUTTING = 1, HOLEBOY = 2, DONE = 3, DEAD = 4
    }

    public BodyState bodyState = BodyState.NEW;
    public GameObject flacidBody;
    public GameObject turgidBody;

    private GameObject flacidBoi;
    private GameObject turgidBoi;

    private bool givenScore = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance) instance = this;
    }
    public void StartGame()
    {
        StartCoroutine("GameLoop");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch(bodyState)
            {
                case BodyState.NEW:
                    break;
                case BodyState.CUTTING:
                    FinishedCutting(); 
                    break;
                case BodyState.HOLEBOY:
                    DoneWithThisOne(); 
                    break;
                case BodyState.DONE:
                    break;
                case BodyState.DEAD:
                    break;
            }
        }
    }

    // Update is called once per frame
    private IEnumerator GameLoop()
    {
        yield return new WaitForSeconds(4); 
        while (true)
        {
            switch (bodyState)
            {
                case BodyState.NEW:
                    flacidBoi = Instantiate(flacidBody);
                    givenScore = false;  
                    
                    foreach(Transform child in flacidBoi.transform)
                    {
                        if (child.GetComponent<Rigidbody>())
                        {
                            boiRbody = child.GetComponent<Rigidbody>();
                            break;
                        }
                    }

                    boiRbody.constraints = RigidbodyConstraints.None;

                    yield return new WaitForSeconds(0.5f);
                    AudioManager.instance.PlayScream();
                    yield return new WaitForSeconds(1f);
                    AudioManager.instance.PlaySpecificOneShot("Body_fall");
                    boiRbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                    

                    bodyState = BodyState.CUTTING;
                    break;

                case BodyState.CUTTING:
                    break;

                case BodyState.HOLEBOY:
                    break;

                case BodyState.DONE:
                    if (flacidBoi == null)
                    {
                        bodyState = BodyState.NEW;
                        break;
                    }

                    boiRbody.constraints = RigidbodyConstraints.None;

                    flacidBoi.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(new Vector3(25000, 0, 0));
                    //Destroy(flacidBoi, 2f);
                    flacidBoi = null; 
                    bodyState = BodyState.NEW;
                    break;
            }
            yield return null; 
        }
    }

    public void FinishedCutting()
    {
        if (bodyState == BodyState.CUTTING)
            bodyState = BodyState.HOLEBOY;
        flacidBoi.SetActive(false);
        if (!turgidBoi)
            turgidBoi = Instantiate(turgidBody);
        turgidBoi.transform.GetComponentInChildren<SpawnOrgans>().FillBody();
    }
    public void DoneWithThisOne()
    {
        if (GameManager.Instance.GetBodyState() == true)
        {
            if (givenScore != true)
            {
                givenScore = true;
                GameManager.Instance.GiveScore();
            }
        }
        if (turgidBoi)
            Destroy(turgidBoi);
        if (flacidBoi)
            flacidBoi.SetActive(true); 

        bodyState = BodyState.DONE; 
    }
}
