using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private List<Sound> sounds;

    public static AudioManager Instance;

    public bool isMusicOn = true;
    public bool isSFXOn = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        LoadSounds();
        PlayTheme();
    }

    private void LoadSounds()
    {
        foreach (var sound in sounds)
            sound.Load(gameObject.AddComponent<AudioSource>());
    }


    public void PlaySound(string soundName)
    {
        var sound = sounds.Find(sound => sound.name == soundName);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
            return;
        }
        sound.Source.Play();
    }

    public void PlayButtonClick()
    {
        PlaySound("ButtonClick");
    }
    private void PlayTheme()
    {
        PlaySound("Theme");
    }

    public void ChangeSfxVolume(bool isNotMuted)
    {
        isSFXOn = isNotMuted;
        foreach(var sound in sounds)
            if(sound.name != "Theme")
            {
                sound.ChangeVolume(isNotMuted);
            }
    }

    public void ChangeMusicVolume(bool isNotMuted)
    {
        isMusicOn = isNotMuted;
        foreach (var sound in sounds)
            if (sound.name == "Theme")
            {
                sound.ChangeVolume(isNotMuted);
            }

    }
}

