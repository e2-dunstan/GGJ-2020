using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FTW : MonoBehaviour
{
    [SerializeField] private SpriteRenderer ftw;
    private Color alphaIncrease = new Color(0, 0, 0, 0.002f);
    private float floatAlphaIncrease = 1f;
    private Color ftwAlphaIncrease;
    private GameObject secondCamera;

    private void Awake()
    {
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
        //int scene = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            GameManager.Instance.EnableEndUI();
            StartCoroutine(DudeSpawner.Instance.SpawnCompletedDudes());
            Camera.main.gameObject.GetComponent<AudioListener>().enabled = false;
            Camera.main.gameObject.GetComponent<Camera>().enabled = false;
            secondCamera.GetComponent<Camera>().enabled = true;
            secondCamera.GetComponent<AudioListener>().enabled = true;


        }
        yield return null;
    }

    public void SetSecondCamera(GameObject _cam)
    {
        secondCamera = _cam;
    }
}
