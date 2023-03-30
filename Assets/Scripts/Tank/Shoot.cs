using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private GameObject turret;
    public GameObject bulletPrefab;

    private void Start()
    {
        turret = gameObject;
    }
    private void ToShoot()
    {
        Instantiate(bulletPrefab, turret.transform.position, turret.transform.rotation);
    }


    public void AssignShootMethodToButton(Controls controls)
    {
        controls.addListenerToFireButton(ToShoot);
    }
}
