using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] private GameObject projectile, gun;
    private AttackerSpawner myLaneSpawner;
    private Animator animator;
    private GameObject projectileParent;
    private const string PROJECTILE_PARENT_NAME = "Projectiles";
    
    
    private void Start() {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();

    }
    
    private void CreateProjectileParent() {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent) {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
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
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation) as GameObject;

        newProjectile.transform.parent = projectileParent.transform;
    }
}
