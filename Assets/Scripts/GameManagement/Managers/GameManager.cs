using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    protected Player firstPlayer, secondPlayer;
    [SerializeField]
    private Transform firstSpawn, secondSpawn;
    [SerializeField]
    private Controls firstPlayerControls, secondPlayerControls;
    [SerializeField]
    protected UIManager uiManager;


    protected void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }
    virtual public void StartGame(GameObject spawnPoints, GameObject controllers, UIManager uiManager)
    {
        firstSpawn = spawnPoints.transform.Find("FirstSpawn").transform;
        secondSpawn = spawnPoints.transform.Find("SecondSpawn").transform;
        firstPlayerControls = controllers.transform.Find("FirstPlayerControls").GetComponent<Controls>();
        secondPlayerControls = controllers.transform.Find("SecondPlayerControls").GetComponent<Controls>();
        this.uiManager = uiManager;

        CreatePlayers();

    }
    private void CreatePlayers()
    {

        firstPlayer = new Player(firstSpawn, firstPlayerControls);
        secondPlayer = new Player(secondSpawn, secondPlayerControls);
    }

    abstract public void ReceiveNotificationOfTheTankDestruction(GameObject destroyedTank);

    protected bool IsGameEnded(int neededScoreToEndTheGame)
    {
        if (firstPlayer.Score < neededScoreToEndTheGame && secondPlayer.Score < neededScoreToEndTheGame)
            return false;

        return true;
    }

    

    protected void EndGame()
    {
        uiManager.OpenEndGameScreen(firstPlayer.Score, secondPlayer.Score);
    }

}
