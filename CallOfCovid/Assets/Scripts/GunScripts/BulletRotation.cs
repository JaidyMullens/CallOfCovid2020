using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Invoke("destroyObject", 0.5f);
        Destroy(this.gameObject);
    }

    void destroyObject()
    {
        //Destroy(this.gameObject);
    }
}
