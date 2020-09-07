using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle") 
        {
            Debug.Log("you dummy you didnt watch ");
            player.GetComponent<Rigidbody>().AddForce(0, 10000, -80000);
            
        }
    }
    
}
