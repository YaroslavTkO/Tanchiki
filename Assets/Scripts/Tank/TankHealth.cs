using UnityEngine;

public class TankHealth : MonoBehaviour
{
    private GameObject tank;

    readonly private int _hitpoints = 4;
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
        GameManager.Instance.FinishRound(tank);
        Destroy(tank);
    }
}
