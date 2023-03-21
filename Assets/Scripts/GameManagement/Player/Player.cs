using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private GameObject tank;
    private int score = 0;
    private Vector3 respawnPoint;
    readonly private Controls controls;

    public int Score { get { return score; } }

    public Player(GameObject tankPrefab, Vector3 respawnPoint, Controls controls)
    {
        this.respawnPoint = respawnPoint;
        this.controls = controls;
        SpawnTank(tankPrefab);

    }

    public void AddScore()
    {
        ++score;
    }
    public bool IsTankEquals(GameObject tank)
    {
        return this.tank == tank;
    }

    public void SpawnTank(GameObject tankPrefab)
    {
        tank = Object.Instantiate(tankPrefab, respawnPoint, Quaternion.identity);
        SetControlsToTank();

    }
    private void SetControlsToTank()
    {
        if (tank.TryGetComponent<TankMovement>(out var tankMovement))
        {
            tankMovement.Controls = controls;
        }

        var turretController = tank.GetComponentInChildren<TurretController>();
        if (turretController != null)
            turretController.Controls = controls;
        var shoot = tank.GetComponentInChildren<Shoot>();
        if (shoot != null)
            shoot.AssignShootMethodToButton(controls);

    }

}
