﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject bulletObject = Instantiate (bulletPrefab);
            bulletObject.transform.position = transform.position = playerCamera.transform.forward;
            bulletObject.transform.forward = playerCamera.transform.forward;
        }
    }
}
