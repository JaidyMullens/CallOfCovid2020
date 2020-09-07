using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public GameObject player;

    Rigidbody playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = player.gameObject.GetComponent<Rigidbody>();
    }


    public float sidewaysForce = 1800f;
    public float forwardForce = 100000f;

    void FixedUpdate()
    {
        playerRigidbody.AddForce(0, 0, forwardForce * Time.deltaTime); //adds force to the Z axis

        if (Input.GetKey("a"))
        {
            playerRigidbody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }


        if (Input.GetKey("d"))
        {
            playerRigidbody.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }
    }
}
