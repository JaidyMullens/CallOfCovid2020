using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public GameManager gameManager;

    private float recordTime;
    private void OnTriggerEnter(Collider other)
    {

        unloadScene();

        SceneManager.LoadScene("Finish");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void unloadScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }


}
