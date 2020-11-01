using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    public int rotationSpeed = 100;
    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
