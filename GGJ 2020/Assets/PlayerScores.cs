using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour
{
    public static PlayerScores instance;

    public Text[] players;
    public int[] scores;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].text = scores[i].ToString();
        }
    }


}
