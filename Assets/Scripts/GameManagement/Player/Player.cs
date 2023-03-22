using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private GameObject tank;
    private int score = 0;
    private Vector3 respawnPoint;
    readonly private Controls controls;

    private GameObject GetTankPrefab { get { return Resources.Load("Tank") as GameObject; } }

    public int Score { get { return score; } }

    public Player(Vector3 respawnPoint, Controls controls)
    {
        this.respawnPoint = respawnPoint;
        this.controls = controls;
        SpawnTank();

    }

    public void AddScore()
    {
        ++score;
    }
    public bool IsTankEquals(GameObject tank)
    {
        return this.tank == tank;
    }
    public void SpawnTank()
    {
        if (tank != null)
            Object.Destroy(tank);
        tank = Object.Instantiate(GetTankPrefab, respawnPoint, Quaternion.identity);

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
