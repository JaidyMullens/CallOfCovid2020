using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider staminaBar;

    public int maxStamina = 300;
    public int currentStamina;


    public static StaminaBar instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void useStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;
        }
        else
        {
            Debug.Log("Not enough stamina");
        }

       
    }

    public void addStamina(int amount)
    {
        if (currentStamina - amount <= 3000)
        {
            currentStamina += amount;
            staminaBar.value = currentStamina;
        }
    }

    // Update is called once per frame
    
}
