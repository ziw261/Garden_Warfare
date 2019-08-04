using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 *  Attacker.cs
 *  Main Function:
 *     1) Move the Character to left
 *     2) Set the move speed
 *     3) Update the animation state
 *     4) Attack specific target
 */

public class Attacker : MonoBehaviour {
    
    [Range (0f, 5f)] [SerializeField] private float currentSpeed = 1f;
    private GameObject currentTarget;

    private void Awake() {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy() {

        LevelController levelController = FindObjectOfType<LevelController>();

        if (levelController != null) {
            levelController.AttackerKilled();
        }
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState() {
        if (!currentTarget) {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }


    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
    }

    public void Attack(GameObject target) {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage) {
        if (!currentTarget) {
            return;
        }

        Health health = currentTarget.GetComponent<Health>();

        if (health) {
            health.DealDamage(damage);
        }

    }
}
