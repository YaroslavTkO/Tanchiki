using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private GameObject turret;
    public GameObject bulletPrefab;
    
    void Start()
    {
        turret = gameObject;
        
    }
    void Update()
    {
        ToShoot();
    }

    private void ToShoot()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            var obj = Instantiate(bulletPrefab, turret.transform.position + turret.transform.right, Quaternion.identity);
            obj.GetComponent<Bullet>().Direction = turret.transform.right;
        }
    }
}
