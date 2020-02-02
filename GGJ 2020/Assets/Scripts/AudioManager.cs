using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] oneShots;
    public AudioClip[] screams;
    public AudioClip[] ouch; 
    public AudioClip[] quips;
    public AudioClip[] splats;
    public AudioClip[] cheers;
    public AudioClip[] lostThem; 
    public static AudioManager instance;

    public void Start()
    {
        if (!instance) instance = this;
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
        if (good)
        {
            int i = Random.Range(0, cheers.Length - 1);
            StartCoroutine(playSound(cheers[i]));
        }
        else
        {
            int i = Random.Range(0, lostThem.Length - 1);
            StartCoroutine(playSound(lostThem[i]));
        }
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
    private IEnumerator playSound(AudioClip clip)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = clip;
        audio.Play();
        yield return new WaitForSeconds(clip.length);
    }
}
