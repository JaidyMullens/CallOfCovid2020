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

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        playerHealth = playerManager.player.GetComponent<Health>();

        //armor
        currentArmor = 0;
        playerArmor.SetArmor(currentArmor);
      
    
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

   
    }

    void unloadScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }

  
}
