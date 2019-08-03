using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] private GameObject projectile, gun;
    private AttackerSpawner myLaneSpawner;
    private Animator animator;

    private void Start() {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }


    private void Update() {
        
        if (IsAttackerInLane()) {
            animator.SetBool("isAttacking", true);
        }
        else {
            animator.SetBool("isAttacking", false);
        }
        
    }

    private void SetLaneSpawner() {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner attackerSpawner in attackerSpawners) {
            bool isCloseEnough = (Mathf.Abs(attackerSpawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            //Debug.Log("attackerSpawner: "+ attackerSpawner.transform.position.y);
            //Debug.Log("this shooter: "+ transform.position.y);

            if (isCloseEnough) {
                myLaneSpawner = attackerSpawner;
                //Debug.Log("Yep");
            }
        }
    }


    private bool IsAttackerInLane() {
       
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }
        else {
            return true;
        }
    }
    
    public void Fire() {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
}
