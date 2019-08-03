using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 *  Health.cs
 *  Main Function
 *     1) Track current health
 *     2) Decrease health
 */

public class Health : MonoBehaviour {

    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject deathVFX;

    public void DealDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX() {
        if (!deathVFX) {
            return;
        }

        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}
