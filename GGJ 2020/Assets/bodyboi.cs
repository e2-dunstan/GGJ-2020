using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyboi : MonoBehaviour
{
    public enum BodyState
    {
        NEW = 0, CUTTING = 1, HOLEBOY = 2, DONE = 3
    }

    public BodyState bodyState = BodyState.NEW;
    public GameObject flacidBody;
    public GameObject turgidBody;

    private GameObject flacidBoi;
    private GameObject turgidBoi; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GameLoop"); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bodyState = BodyState.HOLEBOY; 
        }
    }

    // Update is called once per frame
    private IEnumerator GameLoop()
    {
        //while (true)
        switch (bodyState)
        {
            case BodyState.NEW:
                flacidBoi = Instantiate(flacidBody);
                yield return null; 
                break;

            case BodyState.CUTTING:

                break;

            case BodyState.HOLEBOY:
                Destroy(flacidBody); 
                turgidBoi = Instantiate(turgidBody); 
                break;

            case BodyState.DONE:

                break;
        }
    }
}
