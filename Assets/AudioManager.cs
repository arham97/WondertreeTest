using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip die;
    public AudioClip jump;
    public AudioClip collect;
    AudioSource audioSource;

    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void deadS()
    {
        audioSource.PlayOneShot(die);
    }

    public void jumpS()
    {
        audioSource.PlayOneShot(jump, 0.7F);
    }

    public void CoinSounds()
    {
        audioSource.PlayOneShot(collect, 0.7F);
    }
}
