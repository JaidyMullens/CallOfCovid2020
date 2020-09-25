using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn = GameObject.Find("BulletSpawn").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject bulletObject = Instantiate (bulletPrefab);
            bulletObject.transform.position = bulletSpawn.position;
            bulletObject.transform.forward = playerCamera.transform.forward;
        }
    }
}
