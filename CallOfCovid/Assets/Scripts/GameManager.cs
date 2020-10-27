using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Health playerHealth;

    void Start()
    {
        playerHealth = GameObject.Find("TestPlayer").GetComponent<Health>();
    }


}
