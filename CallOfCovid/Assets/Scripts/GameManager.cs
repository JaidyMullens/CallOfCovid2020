using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Health playerHealth;
    public PlayerManager playerManager;
    public Armor playerArmor;

    public int currentArmor;
    public int maxArmor = 4;

    public Text timerText;

    public float timerCount = 0f;

    public bool timerActive = false;
    void Start()
    {

        playerHealth = playerManager.player.GetComponent<Health>();

        //armor
        currentArmor = 0;
        playerArmor.SetArmor(currentArmor);
        timerActive = true;

        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (playerHealth != null)
        {
            if (playerHealth.health == 0)
            {
                unloadScene();

                SceneManager.LoadScene("Dead", LoadSceneMode.Single);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;


            }
        }
    

        if (timerActive)
        {
            timerCount += Time.deltaTime;
        }

        if (timerText != null)
        {
            timerText.text = "Time: " + timerCount.ToString("F2");
        }

       
    }

    void unloadScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }


}
