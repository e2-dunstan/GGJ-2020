using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private DudeSpawner dudeSpawner;
    private int totalScore = 0;
    private int p1Score = 0;
    private int p2Score = 0;
    private int p3Score = 0;
    private int p4Score = 0;
    private GameObject currentBody;


    public bool currentDudeAlive = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(dudeSpawner.SpawnCompletedDudes());
        }
    }

    public void NextBody()
    {

    }

    public void GiveScore()
    {
        totalScore++;
    }

    public int GetScore()
    {
        return totalScore;
    }

    public void SetCurrentBody(GameObject _body)
    {
        currentBody = _body;
    }

    public bool GetBodyState()
    {
        if (!currentBody) { return false; }
        switch(currentBody.GetComponent<Body>().bodyState)
        {
            case Body.BodyLivingState.SAVED:
                {
                    return true;
                }
            case Body.BodyLivingState.DEAD:
                {
                    return false;
                }
        }
        Debug.LogError("Shouldn't be here mate - Body is saved btw");
        return false;
    }
}
