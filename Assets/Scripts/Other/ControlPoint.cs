using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    private KingOfTheHill receiver;
    private Dictionary<GameObject, IEnumerator> objectsInCollision;

    private void Start()
    {
        objectsInCollision = new Dictionary<GameObject, IEnumerator>();
    }

    public KingOfTheHill Receiver
    {
        set
        {
            if (receiver == null)
                receiver = value;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<TankHealth>(out _))
        {
            var cor = ExecuteForTankInCollision(collision.gameObject);
            objectsInCollision.Add(collision.gameObject, cor);
            StartCoroutine(cor);
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<TankHealth>(out _))
        {
            StopCoroutine(objectsInCollision[collision.gameObject]);
            objectsInCollision.Remove(collision.gameObject);
        }

    }

    private IEnumerator ExecuteForTankInCollision(GameObject tank)
    {
        while (receiver != null)
        {
            AudioManager.Instance.PlaySound("Point");
            receiver.ReceiveTankThatControlsPoint(tank);
            yield return new WaitForSeconds(1f);
        }
    }
}
