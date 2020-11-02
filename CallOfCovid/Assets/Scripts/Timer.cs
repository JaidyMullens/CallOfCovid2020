using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text highscore;
    private GameManager gameManager;
    void Start()
    {
        Invoke("unloadScene", 4.5f);
        Invoke("loadMenu", 5f);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        highscore.text = "Your time: " + gameManager.timerCount.ToString("F2");
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
