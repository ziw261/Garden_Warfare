using System;
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
    private GameObject deathVfxParent;
    private const string DEATHVFX_PARENT_NAME = "DeathVfx";


    private void Start() {
        CreateDeathVfxParent();
    }

    private void CreateDeathVfxParent() {
        deathVfxParent = GameObject.Find(DEATHVFX_PARENT_NAME);
        if (!deathVfxParent) {
            deathVfxParent = new GameObject(DEATHVFX_PARENT_NAME);
        }
    }


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
        deathVFXObject.transform.parent = deathVfxParent.transform;
        Destroy(deathVFXObject, 1f);
    }
}
