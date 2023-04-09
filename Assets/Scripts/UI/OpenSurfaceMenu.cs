using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSurfaceMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject surfaceMenuPrefab;
    private GameObject surfaceMenu;

    private GameObject canvas;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OpenMenu);
        canvas = FindObjectOfType<Canvas>().gameObject;
    }
    public void OpenMenu()
    {
            surfaceMenu = Instantiate(surfaceMenuPrefab, canvas.transform);
    }
}
