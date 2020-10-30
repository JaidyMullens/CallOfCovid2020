using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public void DoQuit()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
