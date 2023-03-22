using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject bullet;
    private Vector3 direction = Vector3.zero;

    readonly private int damage = 1;
    readonly private float speed = 18f;
    readonly private float lifeTime = 4f;
    private float lifeTimeTimer = 0;

    private bool leftOriginalTankCollider = false;

    public Vector3 Direction
    {
        set { direction = value; }
    }

    private void Start()
    {
        bullet = gameObject;
        lifeTimeTimer = Time.time;
        
    }

    private void Update()
    {
        MoveBullet();
        LifeCountdown();
    }
    private void MoveBullet()
    {
        bullet.transform.Translate(speed * Time.deltaTime * direction);

    }
    
    private void LifeCountdown()
    {
        if(Time.time - lifeTimeTimer >= lifeTime)
        {
            Destroy(bullet);
        }

    }

    private void DamageTank(GameObject tank)
    {
        if(tank.TryGetComponent<TankHealth>(out var tankClass))
        {
            tankClass.changeHp(-damage);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (leftOriginalTankCollider)
        {
            DamageTank(collision.gameObject);
            Destroy(bullet);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        leftOriginalTankCollider = true;
    }
}
