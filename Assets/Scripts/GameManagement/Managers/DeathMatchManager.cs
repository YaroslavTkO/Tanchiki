using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMatchManager : GameManager
{
    override public void ReceiveNotificationOfTheTankDestruction(GameObject destroyedTank)
    {
        if (firstPlayer.IsTankEquals(destroyedTank))
        {
            secondPlayer.AddScore();
        }
        else if (secondPlayer.IsTankEquals(destroyedTank))
        {
            firstPlayer.AddScore();
        }

        if (IsGameEnded(5))
            EndGame();
        else StartCoroutine(StartNewRound());

    }

    protected override void SetObjectiveText()
    {
        uiManager.OpenStartingScreen("Destroy enemy tank 5 times");
    }

    private IEnumerator StartNewRound()
    {

        uiManager.OpenBetweenRoundsScreen(firstPlayer.Score, secondPlayer.Score);

        yield return new WaitForSeconds(3);

        firstPlayer.SpawnTank();
        secondPlayer.SpawnTank();
    }
}
