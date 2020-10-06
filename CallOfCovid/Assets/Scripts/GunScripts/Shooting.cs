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
            // Debug.Log(); Voor console testen
            // Debug.Log(shootingPoint.rotation);
            GameObject shot = GameObject.Instantiate(projectile, shootingPoint.position, shootingPoint.rotation * Quaternion.Euler(90f, 90f, 0f));
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
        }
    }
}