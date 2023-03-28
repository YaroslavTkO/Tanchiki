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
        var obj = Instantiate(bulletPrefab, turret.transform.position, Quaternion.identity);
        obj.GetComponent<Bullet>().Direction = turret.transform.right;
    }


    public void AssignShootMethodToButton(Controls controls)
    {
        controls.addListenerToFireButton(ToShoot);
    }
}
