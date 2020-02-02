using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] music; 
    public AudioClip[] oneShots;
    public AudioClip[] screams;
    public AudioClip[] ouch; 
    public AudioClip[] quips;
    public AudioClip[] splats;
    public AudioClip[] cheers;
    public AudioClip[] slaps; 
    public static AudioManager instance;

    private float quipTimerDelay = 10.0f;
    private float quipTimer = 0.0f;
    private int musicnum = 0; 
    public void Start()
    {
        if (!instance) instance = this;
        StartCoroutine(PlayMusic()); 
    }

    private void Update()
    {
        if (musicnum == 1)
        {
            quipTimer += Time.deltaTime;

            if (quipTimer > quipTimerDelay)
            {
                quipTimerDelay = Random.Range(5, 10);
                PlayQuip();
                quipTimer = 0.0f;
            }
        }
    }
    public void nextMusic()
    {
        if (musicnum == 0)
            musicnum++;
        else
            musicnum = 0; 
    }
    public IEnumerator PlayMusic()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = music[musicnum];
        audio.loop = true;
        audio.Play();
        while (musicnum == 0)
            yield return null;
        while (audio.volume > 0.25f)
        {
            yield return null; 
            audio.volume -= 0.01f;
        }
        audio.volume = 0.25f; 
        audio.Stop();
        audio.clip = music[musicnum];
        audio.loop = true;
        audio.Play();
        while (audio.volume < 0.6f)
        {
            audio.volume += 0.01f;
            yield return null;
        }
        audio.volume = 0.6f;
        while (true)
        yield return null;
    }

    public void PlaySpecificOneShot(string soundName)
    {
        for (int i = 0; i < oneShots.Length; ++i)
            if (oneShots[i].name == soundName)
                StartCoroutine(playSound(oneShots[i])); 
    }
    public void PlayScream()
    {
        int i = Random.Range(0, screams.Length - 1);
        StartCoroutine(playSound(screams[i])); 
    }
    public void PlayQuip()
    {
        int i = Random.Range(0, quips.Length - 1);
        StartCoroutine(playSound(quips[i]));
    }
    public void FinishedWithBodySound(bool good = true)
    {
        int i = Random.Range(0, cheers.Length - 1);
        StartCoroutine(playSound(cheers[i]));
    }
    public void SplatFX()
    {
        int i = Random.Range(0, splats.Length - 1);
        StartCoroutine(playSound(splats[i]));
    }
    public void OuchNoise()
    {
        int i = Random.Range(0, ouch.Length - 1);
        StartCoroutine(playSound(ouch[i]));
    }
    public void HandSlaps()
    {
        int i = Random.Range(0, slaps.Length - 1);
        StartCoroutine(playSound(slaps[i]));
    }
    private IEnumerator playSound(AudioClip clip)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = clip;
        audio.Play();
        yield return new WaitForSeconds(clip.length);
    }
}
