using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private GameObject tank;
    private int score = 0;
    private Vector3 respawnPoint;

    public int Score { get { return score; } }

    public Player(GameObject tankPrefab, Vector3 respawnPoint)
    {
        this.respawnPoint = respawnPoint;
        SpawnTank(tankPrefab);
    }

    public void AddScore()
    {
       ++score;
    }

    public void SpawnTank(GameObject tankPrefab)
    {
        tank = Object.Instantiate(tankPrefab, respawnPoint, Quaternion.identity);
    }

    public bool IsTankEquals(GameObject tank)
    {
        return this.tank == tank;
    }

}
