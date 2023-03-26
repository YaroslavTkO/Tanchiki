using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerInstantiator : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPoints;
    [SerializeField]
    private GameObject controllers;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private SelectedData data;
    void Start()
    {
        if (data.gameMode == "Deathmatch")
            gameObject.AddComponent<DeathMatchManager>();
        else if (data.gameMode == "King of the hill")
            gameObject.AddComponent<KingOfTheHill>();


        GameManager.Instance.StartGame(spawnPoints, controllers, uiManager);

    }
}
