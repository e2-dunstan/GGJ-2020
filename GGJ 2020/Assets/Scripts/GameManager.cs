using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private DudeSpawner dudeSpawner;
    private int score = 5;

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

    public int GetScore()
    {
        return score;
    }
}
