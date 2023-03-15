using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private GameObject turret;
    public GameObject bulletPrefab;

    readonly private float reloadTime = 1f;
    private float reloadTimeTimer = 0f;

    private void Start()
    {
        turret = gameObject;
        reloadTimeTimer = Time.time;

    }
    private void Update()
    {
        ToShoot();
    }

    private void ToShoot()
    {
        if (Input.GetKey(KeyCode.Return) && Reloaded())
        {
            var obj = Instantiate(bulletPrefab, turret.transform.position, Quaternion.identity);
            obj.GetComponent<Bullet>().Direction = turret.transform.right;
        }
    }

    private bool Reloaded()
    {
        if(Time.time - reloadTimeTimer >= reloadTime)
        {
            reloadTimeTimer = Time.time;
            return true;
        }
        return false;
    }
}
