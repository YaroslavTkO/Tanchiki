using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject bullet;
    private Vector3 direction = Vector3.zero;


    readonly private float speed = 18f;
    readonly private float lifeTime = 4f;
    private float lifeTimeTimer = 0;

    private bool leftTankCollision = false;

    public Vector3 Direction
    {
        set { direction = value; }
    }

    void Start()
    {
        bullet = gameObject;
        lifeTimeTimer = Time.time;
        
    }

    void Update()
    {
        MoveBullet();
        LifeCountdown();
    }
    private void MoveBullet()
    {
        bullet.transform.Translate(direction * speed * Time.deltaTime);

    }
    
    private void LifeCountdown()
    {
        if(Time.time - lifeTimeTimer >= lifeTime)
        {
            Destroy(bullet);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (leftTankCollision)
        {
            Debug.Log("Booom!");

            Destroy(bullet);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        leftTankCollision = true;
    }
}
