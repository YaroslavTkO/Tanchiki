using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private Player firstPlayer, secondPlayer;
    [SerializeField]
    private Transform firstSpawn, secondSpawn;
    [SerializeField]
    private Controls firstPlayerControls, secondPlayerControls;

    readonly private int RoundTime = 90;
    private float RoundTimer = 0;

    private GameObject GetTankPrefab { get { return Resources.Load("Tank") as GameObject; } }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartGame();
    }
    private void Update()
    {
        Timer();
    }

    private void StartGame()
    {
        var tankPrefab = GetTankPrefab;

        firstPlayer = new Player(tankPrefab, firstSpawn.position, firstPlayerControls);
        secondPlayer = new Player(tankPrefab, secondSpawn.position, secondPlayerControls);

        RoundTimer = Time.time;
    }

    private void Timer()
    {
        if(Time.time - RoundTimer >= RoundTime)
        {
            //EndGame


            CalculateWinner();

            Destroy(gameObject);
        }
    }
    public void RespawnPlayers(GameObject destroyedTank)
    {
        if (firstPlayer.IsTankEquals(destroyedTank))
        {
            secondPlayer.AddScore();
            firstPlayer.SpawnTank(GetTankPrefab);

        }
        else if (secondPlayer.IsTankEquals(destroyedTank))
        {
            firstPlayer.AddScore();
            secondPlayer.SpawnTank(GetTankPrefab);

        }
    }
    public void CalculateWinner()
    {
        Debug.Log(firstPlayer.Score + "----" + secondPlayer.Score);

        if (firstPlayer.Score > secondPlayer.Score)
            Debug.Log("First player won!");
        else if (firstPlayer.Score < secondPlayer.Score)
            Debug.Log("Secon player won!");
        else Debug.Log("Draw!");

    }
}
