using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    [Range(0f, 1f)]
    private float volume = 1f;
    [SerializeField]
    [Range(0.3f, 3f)]
    private float pitch = 1f;
    [SerializeField]
    private bool loop = false;

    private AudioSource source;
    public AudioSource Source { get { return source; } }

    public string name;

    public void Load(AudioSource source)
    {
        this.source = source;
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;

    }


}
