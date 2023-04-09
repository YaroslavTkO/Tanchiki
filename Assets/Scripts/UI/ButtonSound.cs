using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{

    private void Start()
    {
        if(TryGetComponent<Button>(out var button))
        {
            button.onClick.AddListener(AudioManager.Instance.PlayButtonClick);
        }
    }
    private void OnDestroy()
    {
        if(TryGetComponent<Button>(out var button))
            button.onClick.RemoveAllListeners();
        
    }
}
