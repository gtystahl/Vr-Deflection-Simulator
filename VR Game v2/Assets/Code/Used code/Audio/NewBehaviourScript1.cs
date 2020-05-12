using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homk : MonoBehaviour
{
    public GameObject aud;

    public AudioClip musicClip;

    public AudioSource musicSource;

    public float time;
    private bool timeOff;

    // Use this for initialization
    void Start()
    {
        time = 0;
        timeOff = false;
        //musicSource.clip = musicClip;
        //musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeOff)
        {
            time += Time.deltaTime;
        }

        if (time >= 20)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
            time = 0;
            timeOff = true;
        }

        if (aud.GetComponent<audioStuff>().enabled)
        {
            this.enabled = false;
        }
    }
}
