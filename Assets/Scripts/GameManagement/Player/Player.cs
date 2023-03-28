using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private GameObject tank;
    private int score = 0;
    readonly private Transform respawnPoint;
    readonly private Controls controls;

    private GameObject GetTankPrefab { get { return Resources.Load("Tank") as GameObject; } }

    public int Score { get { return score; } }

    public Player(Transform respawnPoint, Controls controls)
    {
        this.respawnPoint = respawnPoint;
        this.controls = controls;
        SpawnTank();

    }

    public void AddScore()
    {
        ++score;
        controls.UpdateScoreDisplay(score);
    }
    public bool IsTankEquals(GameObject tank)
    {
        return this.tank == tank;
    }
    public void SpawnTank()
    {
        if (tank != null)
            Object.Destroy(tank);
        tank = Object.Instantiate(GetTankPrefab, respawnPoint.position, respawnPoint.rotation);

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

        controls.RemoveListenersFromFireButton();
        var shoot = tank.GetComponentInChildren<Shoot>();
        if (shoot != null)
            shoot.AssignShootMethodToButton(controls);

    }

}
