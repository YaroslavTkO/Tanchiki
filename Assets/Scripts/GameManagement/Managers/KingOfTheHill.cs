using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingOfTheHill : GameManager
{
    [SerializeField]
    readonly private GameObject controlPointPrefab;

    private GameObject controlPoint;
    public override void ReceiveNotificationOfTheTankDestruction(GameObject destroyedTank)
    {
        if (firstPlayer.IsTankEquals(destroyedTank))
            firstPlayer.SpawnTank();
        else secondPlayer.SpawnTank();
    }
    override protected void Start()
    {
        base.Start();
        controlPoint = Instantiate(controlPointPrefab);
        
    }
}
