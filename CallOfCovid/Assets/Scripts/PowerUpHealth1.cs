using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth1 : MonoBehaviour
{
    //public GameObject pickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {

        Health hp = player.GetComponent<Health>();
        hp.health += 1;

        Destroy(gameObject);
    }
}
