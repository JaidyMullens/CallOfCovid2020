using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{ 
    public void level2()
    {
        SceneManager.LoadScene("Level 02", LoadSceneMode.Single);
    }
}
