using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] oneShots;

    public void PlayOneShot(AudioSource source)
    {
        int rand = Random.Range(0, oneShots.Length - 1);
        source.PlayOneShot(oneShots[rand]);
    }
}
