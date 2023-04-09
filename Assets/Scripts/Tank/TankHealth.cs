using UnityEngine;

public class TankHealth : MonoBehaviour
{
    private GameObject tank;

    readonly private int _hitpoints = 3;
    private int _currentHitpoints;

    private void Start()
    {
        tank = gameObject;
        _currentHitpoints = _hitpoints;
    }

    public void changeHp(int changeAmount)
    {
        _currentHitpoints += changeAmount;

        if (_currentHitpoints <= 0)
            DestroyTank();
    }

    private void DestroyTank()
    {
        GameManager.Instance.ReceiveNotificationOfTheTankDestruction(tank);
        AudioManager.Instance.PlaySound("TankDeath");
        Destroy(tank);
    }
}
