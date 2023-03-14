using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private GameObject tank;
    private GameObject turret;


    readonly private float _speed = 3f;
    readonly private float _rotationSpeed = 100f;
    void Start()
    {
        tank = gameObject;
    }

    void Update()
    {
        MoveTank();
        RotateTank();
    }

    public void MoveTank()
    {
        if (Input.GetKey(KeyCode.Space))
            tank.transform.position += tank.transform.right * Time.deltaTime * _speed;

    }

    public void RotateTank()
    {
        float rotateAroundZ = -Input.GetAxisRaw("Horizontal") * _rotationSpeed;

        tank.transform.Rotate(0, 0, rotateAroundZ * Time.deltaTime);
    }
}
