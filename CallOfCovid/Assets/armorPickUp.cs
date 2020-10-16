using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armorPickUp : MonoBehaviour
{
    public Armor armor;
    public EnemyController enemyArmor;

    void OnTriggerEnter(Collider Col)
    {
        if (Col.CompareTag("Player"))
            Destroy(gameObject);
    }
    void OnDestroy()
    {
        enemyArmor.currentArmor = enemyArmor.maxArmor;
        armor.slider.value = enemyArmor.currentArmor;
    }
}
