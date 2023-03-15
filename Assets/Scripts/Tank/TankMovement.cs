using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private GameObject tank;

    readonly private float _speed = 3f;
    readonly private float _rotationSpeed = 60f;
    readonly private float backwardSpeedMultiplier = 0.5f;

    private void MoveTank()
    {

        float input = Input.GetAxisRaw("Vertical");
        if (input < 0)
            input *= backwardSpeedMultiplier;

        Vector3 movement = input * tank.transform.right * Time.deltaTime * _speed;
        tank.transform.position += movement;

    }

    private void RotateTank()
    {
        float rotate = -Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime;

        tank.transform.Rotate(0, 0, rotate);
    }

    private void Start()
    {
        tank = gameObject;
    }

    private void Update()
    {
        MoveTank();
        RotateTank();
    }


}
