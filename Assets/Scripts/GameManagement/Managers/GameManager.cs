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


    private void Awake()
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

    private void Start()
    {
        CreatePlayers();
    }
    private void CreatePlayers()
    {

        firstPlayer = new Player(firstSpawn.position, firstPlayerControls);
        secondPlayer = new Player(secondSpawn.position, secondPlayerControls);
    }

    private void EndGame()
    {
        //Show winner & results

        Debug.Log("Game ended\nResults:\nFirst player: " + firstPlayer.Score + "\nSecond player: " + secondPlayer.Score);
        
        //Open End Game Panel

    }

    public void FinishRound(GameObject destroyedTank)
    {
        if (firstPlayer.IsTankEquals(destroyedTank))
        {
            secondPlayer.AddScore();
        }
        else if (secondPlayer.IsTankEquals(destroyedTank))
        {
            firstPlayer.AddScore();
        }

        if (IsGameEnded())
            EndGame();
        else StartCoroutine(StartNewRound());

    }

    private IEnumerator StartNewRound()
    {
        yield return new WaitForSeconds(3);

        firstPlayer.SpawnTank();
        secondPlayer.SpawnTank();
    }

    private bool IsGameEnded()
    {
        if (firstPlayer.Score < 5 && secondPlayer.Score < 5)
            return false;

        return true;
    }
}
