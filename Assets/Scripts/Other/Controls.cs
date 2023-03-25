using System;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    [SerializeField] private Joystick movementJoystick;

    [SerializeField] private Button fireButton;

    private int turretInput;
    public bool TryGetAngleOfMovementJoystick(out float angle)
    {
        angle = 0;

        var x = movementJoystick.Horizontal;
        var y = movementJoystick.Vertical;

        if (x == 0 && y == 0)
            return false;

        var atanAngle = Mathf.Atan(y / x) * 180 / Mathf.PI;
        //1 quadrant
        if (x > 0 && y > 0)
            angle = atanAngle;
        //4 Quadrant
        else if (x > 0 && y < 0)
            angle = atanAngle + 360;

        //2, 3 Quadrant
        else angle = atanAngle + 180;

        return true;
    }
    public float getMovementJoystickSpeed()
    {
        return movementJoystick.Direction.magnitude;
    }
    public float getTurretRotationInput()
    {
        return turretInput;
    }

    public void addListenerToFireButton(Action fireFunction)
    {
        fireButton.onClick.AddListener(() => fireFunction());

    }

    public void RemoveListenersFromFireButton()
    {
        fireButton.onClick.RemoveAllListeners();
    }

    private void OnDestroy()
    {
        RemoveListenersFromFireButton();
    }

    public void ChangeTurretInput(int amountToChange)
    {
        turretInput += amountToChange;
    }





}