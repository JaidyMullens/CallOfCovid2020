using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armorPickUp : MonoBehaviour
{
    public Armor armor;
    public EnemyController enemyArmor;
    public GameManager gameManager;
    void OnTriggerEnter(Collider Col)
    {
        if (Col.CompareTag("Player"))
            Destroy(gameObject);


    }
    void OnDestroy()
    {
        gameManager.currentArmor = gameManager.maxArmor;
        armor.slider.value = gameManager.currentArmor;
    }
}
