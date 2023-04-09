using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private GameObject turret;
    private AudioSource turretAudioSource;
    public GameObject bulletPrefab;

    private void Start()
    {
        turret = gameObject;
        turretAudioSource = turret.GetComponent<AudioSource>();
    }
    private void ToShoot()
    {
        Instantiate(bulletPrefab, turret.transform.position, turret.transform.rotation);
        turretAudioSource.Play();
    }


    public void AssignShootMethodToButton(Controls controls)
    {
        controls.addListenerToFireButton(ToShoot);
    }
}
