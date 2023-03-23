using UnityEngine;

public class TurretController : MonoBehaviour
{

    private GameObject turret;
    private Controls controls;

    readonly private float _rotationSpeed = 60f;

    public Controls Controls
    {
        get { return controls; }
        set
        {
            if (controls == null)
                controls = value;
        }
    }

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
        float rotate = -controls.getTurretRotationInput() * _rotationSpeed * Time.deltaTime;
        turret.transform.Rotate(0, 0, rotate);
    }
}
