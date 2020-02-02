using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour
{
    public static PlayerScores instance;

    public Text[] players;
    [HideInInspector] public int[] scores = { 0 };

    public Text timer;
    private int minutes = 2;
    private int seconds = 30;

    private void Awake()
    {
        if (!instance) instance = this;

        StartCoroutine(Timer());
    }

    void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].text = scores[i].ToString();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameManager.Instance.NextScene();
        }
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            seconds--;
            if (seconds < 0)
            {
                minutes--;
                if (minutes < 0)
                {
                    GameManager.Instance.NextScene();
                    break;
                }
                else
                {
                    seconds = 59;
                }
            }

            timer.text = TimerText();

            yield return new WaitForSeconds(1.0f);
        }
    }

    private string TimerText()
    {
        string str = "";

        str += minutes.ToString() + ":";
        
        if (seconds < 10)
        {
            str += "0";
        }
        str += seconds.ToString();

        return str;
    }
}
