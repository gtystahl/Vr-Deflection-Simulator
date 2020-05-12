using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioStuff : MonoBehaviour
{
    public AudioClip musicClip;

    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }
}
