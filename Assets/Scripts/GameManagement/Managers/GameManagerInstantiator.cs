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
    protected UIManager uiManager;
    void Start()
    {
        //TODO: add script of game manager according to chosen gamemode
        gameObject.AddComponent<DeathMatchManager>();


        GameManager.Instance.StartGame(spawnPoints, controllers, uiManager);

    }
}
