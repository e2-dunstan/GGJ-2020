using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonFade : MonoBehaviour
{
    [SerializeField] private SpriteRenderer ftw;
    private Text playText;
    private Color alphaIncrease = new Color(0, 0, 0, 0.002f);
    private float floatAlphaIncrease = 1f;
    private Color ftwAlphaIncrease;


    private void Awake()
    {
        playText = this.gameObject.GetComponent<Text>();
        ftwAlphaIncrease = new Color(0, 0, 0, floatAlphaIncrease);
    }

    void Update()
    {
        if (Time.time >= 13.5f)
        {
            playText.color += alphaIncrease;
        }
        if (Input.GetButtonDown("Start1"))
        {
            StartCoroutine(NextScene());
        }
    }

    public void NextSceneButton()
    {
        StartCoroutine(NextScene());
    }

    public IEnumerator NextScene()
    {
        Color startColour = new Color(ftw.color.r, ftw.color.g, ftw.color.b, 0);
        Color endColour = new Color(ftw.color.r, ftw.color.g, ftw.color.b, 1);

        for (float t = 0.0001f; t < 1.0; t += Time.deltaTime)
        {
            float progress = t / 1.0f;
            ftw.color = startColour + (endColour - startColour) * progress;
            yield return null;
        }
        ftw.color = endColour;
        AudioManager.instance.nextMusic(); 
        SceneManager.LoadScene(1);
        bodyboi.instance.StartGame(); 
        yield return null;
    }
}
