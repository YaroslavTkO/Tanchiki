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
    private Image selectedMapImage, selectedModeImage;
    private Color selectedColor = new(0.2f, 0.8f, 0.2f, 1);

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

        foreach (var map in data.Maps)
        {
            InstantiateMapCard(map);
        }
        foreach (var mode in data.GameModes)
        {
            InstantiateModeButton(mode);
        }
        var playButton = Instantiate(PlayButtonPrefab, transform);
        playButton.GetComponent<Button>().onClick.AddListener(Play);
    }

    private void InstantiateMapCard(Map map)
    {
        var obj = Instantiate(MapCardPrefab, maps.transform);
        obj.transform.Find("MapImage").GetComponent<Image>().sprite = map.SpriteForMenu;
        obj.GetComponentInChildren<TextMeshProUGUI>().text = map.Name;
        obj.GetComponent<Button>().onClick.AddListener(() => ChooseMap(map.Name, obj));

    }

    private void InstantiateModeButton(string gamemodeName)
    {
        GameObject obj = Instantiate(ModeButtonPrefab, modes.transform);
        obj.GetComponentInChildren<TextMeshProUGUI>().text = gamemodeName;
        obj.GetComponent<Button>().onClick.AddListener(() => ChooseMode(gamemodeName, obj));

    }

    private void ChooseMap(string mapName, GameObject caller)
    {
        selectedData.mapName = mapName;

        if (selectedMapImage != null)
            selectedMapImage.color = Color.black;
        selectedMapImage = caller.GetComponent<Image>();
        selectedMapImage.color = selectedColor;

    }
    private void ChooseMode(string modeName, GameObject caller)
    {
        selectedData.gameMode = modeName;
        if (selectedModeImage != null)
            selectedModeImage.color = Color.white;
        selectedModeImage = caller.GetComponent<Image>();
        selectedModeImage.color = selectedColor;
    }

    private void Play()
    {
        if (selectedData.mapName != "")
            SceneManager.LoadScene(selectedData.mapName);
    }
}