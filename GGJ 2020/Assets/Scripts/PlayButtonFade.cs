using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonFade : MonoBehaviour
{
    private Text playText;
    private Color alphaIncrease = new Color(0, 0, 0, 0.002f);

    private void Awake()
    {
        playText = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        if (Time.time >= 13.5f)
        {
            playText.color += alphaIncrease;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            NextScene();
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
