using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private GameObject turret;

    readonly private float _rotationSpeed = 80f;

    private void Start()
    {
        turret = gameObject;
        
    }

    private void Update()
    {
        RotateTurret();
    }

    private void RotateTurret()
    {
        float rotateLeft = Input.GetKey(KeyCode.Z) ? _rotationSpeed * Time.deltaTime : 0;
        float rotateRight = Input.GetKey(KeyCode.X) ?  -_rotationSpeed * Time.deltaTime : 0;
        turret.transform.Rotate(0, 0, rotateLeft + rotateRight);
    }
}
