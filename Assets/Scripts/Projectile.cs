﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] private float speed = 1f;
    [SerializeField] private float damage = 50f;

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        //Debug.Log("I hit: " + otherCollider.name);

        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health) {
            health.DealDamage(damage);
            Destroy(gameObject);
        }

    }
}
