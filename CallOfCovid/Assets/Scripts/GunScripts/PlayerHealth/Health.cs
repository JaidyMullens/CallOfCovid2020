using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public GameManager gameManager;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
       
        health = gameManager.playerHealth.health;
    }

    void Update()
    {
        
        for (int i = 0; i < hearts.Length; i++)
        {

            if (health > numOfHearts)
            {
                health = numOfHearts;
            }

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
                
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
