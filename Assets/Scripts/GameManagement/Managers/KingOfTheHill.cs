using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingOfTheHill : GameManager
{
    private GameObject ControlPointPrefab { get { return Resources.Load("ControlPoint") as GameObject; } }

    private GameObject controlPoint;
    public override void ReceiveNotificationOfTheTankDestruction(GameObject destroyedTank)
    {
        if (firstPlayer.IsTankEquals(destroyedTank))
            StartCoroutine(RespawnTankWithDelay(firstPlayer));
        else StartCoroutine(RespawnTankWithDelay(secondPlayer));
    }
    override public void StartGame(GameObject spawnPoints, GameObject controllers, UIManager uiManager)
    {
        base.StartGame(spawnPoints, controllers, uiManager);

        controlPoint = Instantiate(ControlPointPrefab);
        if (controlPoint.TryGetComponent<ControlPoint>(out var point))
            point.Receiver = this;


    }
    public void ReceiveTankThatControlsPoint(GameObject tankAtThePoint)
    {
        if (firstPlayer.IsTankEquals(tankAtThePoint))
            firstPlayer.AddScore();
        else if (secondPlayer.IsTankEquals(tankAtThePoint))
            secondPlayer.AddScore();

        if (IsGameEnded(50))
        {
            Destroy(controlPoint);
            EndGame();

        }
    }

    private IEnumerator RespawnTankWithDelay(Player deadPlayer)
    {
        yield return new WaitForSeconds(1f);
        deadPlayer.SpawnTank();
    }
}
