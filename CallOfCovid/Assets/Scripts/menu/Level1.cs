﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{   
    public void level1()
    {
        SceneManager.LoadScene("Level 01", LoadSceneMode.Single);
    }
}
