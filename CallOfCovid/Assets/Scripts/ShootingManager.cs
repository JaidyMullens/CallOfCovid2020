using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingManager : MonoBehaviour
{
    
    public int ammoAmount = 5;

    public Text bulletText;

    
    
    void Update()
    {
        Debug.Log("Amount of ammo: " + ammoAmount);
        checkAmmo();

        bulletText.text = "Bullets: " + ammoAmount + "/" + 45;
    }

    public bool checkAmmo()
    {
        bool containsAmmo = true;

        if (ammoAmount == 0)
        {
            containsAmmo = false;
        }
        else
        {
            containsAmmo = true;
        }

        return containsAmmo;
    }

    public void subtractAmmo()
    {
        if (ammoAmount > 0)
        {
            ammoAmount--;
        }

    }
}
