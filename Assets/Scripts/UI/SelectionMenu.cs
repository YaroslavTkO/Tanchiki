using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionMenu : MonoBehaviour
{
    [SerializeField]
    private DataLists data;
    [SerializeField]
    private SelectedData selectedData;

    private GameObject maps;
    private GameObject modes;

    private GameObject MapsPrefab { get { return Resources.Load("SelectionMenu/Maps") as GameObject; } }
    private GameObject ModesPrefab { get { return Resources.Load("SelectionMenu/Modes") as GameObject; } }  
    private GameObject MapCardPrefab { get { return Resources.Load("SelectionMenu/MapUiPrefab") as GameObject; } }
    private GameObject ModeButtonPrefab { get { return Resources.Load("SelectionMenu/GameModeButton") as GameObject; } }
    private GameObject PlayButtonPrefab { get { return Resources.Load("SelectionMenu/PlayButton") as GameObject; } }

    private void Start()
    {
        maps = Instantiate(MapsPrefab, transform);
        modes = Instantiate(ModesPrefab, transform);
        selectedData.gameMode = "";
        selectedData.mapName = "";

        foreach(var map in data.Maps)
        {
            InstantiateMapCard(map);
        }
        foreach(var mode in data.GameModes)
        {
            InstantiateModeButton(mode);
        }
        var playButton = Instantiate(PlayButtonPrefab, transform);
        playButton.GetComponent<Button>().onClick.AddListener(Play);
    }

    private void InstantiateMapCard(Map map)
    {
        var obj = Instantiate(MapCardPrefab, maps.transform);
        obj.GetComponentInChildren<Image>().sprite = map.SpriteForMenu;
        obj.GetComponentInChildren<TextMeshProUGUI>().text = map.Name;
        obj.GetComponent<Button>().onClick.AddListener(()=>ChooseMap(map.Name));

    }

    private void InstantiateModeButton(string gamemodeName)
    {
        GameObject obj = Instantiate(ModeButtonPrefab, modes.transform);
        obj.GetComponentInChildren<TextMeshProUGUI>().text = gamemodeName;
        obj.GetComponent<Button>().onClick.AddListener(()=>ChooseMode(gamemodeName));

    }

    private void ChooseMap(string mapName)
    {
        selectedData.mapName = mapName;
    }
    private void ChooseMode(string modeName)
    {
        selectedData.gameMode = modeName;
    }

    private void Play()
    {
        if(selectedData.mapName != "")
            SceneManager.LoadScene(selectedData.mapName);
    }
}