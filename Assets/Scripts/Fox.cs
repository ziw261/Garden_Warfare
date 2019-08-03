using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Fox.cs
 * Main function:
 *     1) Listen for Collision
 *     2) specific behavior, jump for fox
 */

public class Fox : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D otherCollider) {
        
        GameObject otherObject = otherCollider.gameObject;
        
        // if this is a gravestone then jump ...

        if (otherObject.GetComponent<Gravestone>()) {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        } else if (otherObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(otherObject);
        }
        
    }
}
