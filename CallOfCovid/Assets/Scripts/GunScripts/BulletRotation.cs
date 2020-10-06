using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour
{
    // float degrees = 90;
    // public Transform rotationGun;

    // Start is called before the first frame update
    void Start()
    {
        // Optie 2

        // rotationGun = GameObject.Find("Gun").GetComponent<Transform>();
        // this.transform.rotation = rotationGun.rotation;

        // Optie 1

        // Vector3 to = new Vector3(degrees, 0, 90);
        // transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
