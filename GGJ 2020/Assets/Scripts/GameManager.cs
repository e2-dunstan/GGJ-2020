using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private DudeSpawner dudeSpawner;
    public int totalScore = 0;
    [SerializeField] private GameObject totalScoreText;
    [SerializeField] private GameObject totalScoreText2;
    [SerializeField] private GameObject timer;
    private int p1Score = 0;
    private int p2Score = 0;
    private int p3Score = 0;
    private int p4Score = 0;
    private GameObject currentBody;
    [SerializeField] private GameObject ftw;


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
        totalScoreText.GetComponent<Text>().text = totalScore.ToString();
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
            case Body.BodyLivingState.ALIVE:
                {
                    return false;
                }
        }
        return false;
    }

    public void NextScene()
    {
        StartCoroutine(ftw.GetComponent<FTW>().NextScene());
    }

    public void EnableEndUI()
    {
        totalScoreText.SetActive(true);
        totalScoreText2.SetActive(true);
        timer.SetActive(false);

    }
}
