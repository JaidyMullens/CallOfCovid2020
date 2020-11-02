using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

  
    void Start()
    {
        Invoke("unloadScene", 4.5f);
        Invoke("loadMenu", 5f);

    }

    void unloadScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }

    void loadMenu()
    {
        SceneManager.LoadScene("MenuTesting", LoadSceneMode.Single);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
