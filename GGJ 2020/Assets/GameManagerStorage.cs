using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerStorage : MonoBehaviour
{
    [SerializeField] private DudeSpawner dudeSpawner;
    public int totalScore = 0;
    [SerializeField] private GameObject totalScoreText;
    [SerializeField] private GameObject totalScoreText2;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject ftw;

    void Awake()
    {
        GameManager.Instance.SetUpBecauseCharlieIsAnAss(dudeSpawner, totalScoreText2, totalScoreText, timer, ftw);

    }

}
