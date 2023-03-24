using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private GameObject tank;
    private Controls controls;

    readonly private float _speed = 3f;
    readonly private float _rotationSpeed = 0.8f;
    readonly private float _backwardSpeedMultiplier = -0.6f;
    readonly private float _backwardRotationSpeedMultiplier = 0.7f;

    public Controls Controls
    {
        get { return controls; }
        set
        {
            if (controls == null)
                controls = value;
        }
    }

    private void ControlTank()
    {

        if (controls.TryGetAngleOfMovementJoystick(out var angle))
        {
            var angleDiff = Mathf.Abs((angle - tank.transform.eulerAngles.z + 180 + 360) % 360 - 180);
            RotateTank(angle, angleDiff);
            MoveTank(angleDiff);
        }
    }

    private void RotateTank(float angleToRotate, float angleDiff)
    {
        var dir = Quaternion.Euler(0, 0, angleToRotate);
        float rotate = _rotationSpeed * Time.deltaTime;

        if (angleDiff > 100)
        {
            dir = Quaternion.Euler(0, 0, (angleToRotate + 180) % 360);
            rotate *= _backwardRotationSpeedMultiplier;
        }
        tank.transform.rotation = Quaternion.Lerp(tank.transform.rotation, dir, rotate);


    }

    private void MoveTank(float angleDiff)
    {

        float inputSpeed = controls.getMovementJoystickSpeed();
        Vector3 movement = _speed * inputSpeed * Time.deltaTime * tank.transform.right;

        if (angleDiff > 100)
            movement *= _backwardSpeedMultiplier;

        tank.transform.position += movement;
    }

    private void Start()
    {
        tank = gameObject;
    }

    private void Update()
    {
        ControlTank();
    }




}
