using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    private AudioSource ac;
    public List<AudioClip> clips;
    private int index;
    // Start is called before the first frame update
    void Awake()
    {
        ac = GetComponent<AudioSource>();
        ac.clip = GetRandomMusic();
        index = clips.FindIndex(a => a.Equals(ac.clip));
        ac.playOnAwake = true;
    }

    private AudioClip GetRandomMusic()
    {
        return clips[UnityEngine.Random.Range(0, clips.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        //if(ac.clip.)
    }
}
