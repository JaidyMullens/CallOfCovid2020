using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour
{
    public KeyCode shootKey = KeyCode.Mouse0;
    public GameObject projectile;
    public float shootForce;
    Transform shootingPoint;

    public KeyCode aimKey = KeyCode.Mouse1;

    Transform gunTransform;

    // Use this for initialization
    void Start()
    {
        shootingPoint = GameObject.Find("shootingPoint").transform;
        gunTransform = GetComponent<Transform>().transform;

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

        if (Input.GetKeyDown(aimKey))
        {
            gunTransform.position = new Vector3(0, gunTransform.position.y, gunTransform.position.z); ;
        }

        Debug.Log(gunTransform.position);

    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);
    }
}