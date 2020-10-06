using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public KeyCode shootKey = KeyCode.F;
    public GameObject projectile;
    public float shootForce;
    Transform shootingPoint;

    // Use this for initialization
    void Start()
    {
        shootingPoint = GameObject.Find("shootingPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            GameObject shot = GameObject.Instantiate(projectile, shootingPoint.position, transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
        }
    }
}