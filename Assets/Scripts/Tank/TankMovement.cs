using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private GameObject tank;
    private Controls controls;

    readonly private float _speed = 3f;
    readonly private float _rotationSpeed = 0.8f;

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
            RotateTank(angle);
            MoveTank();
        }
    }

    private void RotateTank(float angleToRotate)
    {
        var dir = Quaternion.Euler(0, 0, angleToRotate);
        float rotate = _rotationSpeed * Time.deltaTime;

        tank.transform.rotation = Quaternion.Lerp(tank.transform.rotation, dir, rotate);
    }

    private void MoveTank()
    {
        float inputSpeed = controls.getMovementJoystickSpeed();
        Vector3 movement = inputSpeed * tank.transform.right * Time.deltaTime * _speed;
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
