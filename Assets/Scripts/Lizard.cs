using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Lizard.cs
 * Main function:
 *     1) Listen for Collision
 *     2) specific behavior, none for lizard
 */

public class Lizard : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D otherCollider) {
        
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(otherObject);
        }
        
    }
}
