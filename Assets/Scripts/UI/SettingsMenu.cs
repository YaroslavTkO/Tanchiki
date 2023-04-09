using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private Toggle musicToggle, SFXToggle;
    [SerializeField]
    private Button closeButton;


    private void Start()
    {
        musicToggle.isOn = AudioManager.Instance.isMusicOn;
        SFXToggle.isOn = AudioManager.Instance.isSFXOn;
        musicToggle.onValueChanged.AddListener(ToToggleMusic);
        SFXToggle.onValueChanged.AddListener(ToToggleSFX);
        closeButton.onClick.AddListener(CloseSettings);
    }
    private void ToToggleMusic(bool value)
    {
        AudioManager.Instance.ChangeMusicVolume(value); 

    }
    private void ToToggleSFX(bool value)
    {
        AudioManager.Instance.ChangeSfxVolume(value);
    }

    private void CloseSettings()
    {
        Destroy(gameObject);
    }
}
