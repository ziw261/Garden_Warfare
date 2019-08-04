using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/**
 *  LevelController.cs
 *  Main Function:
 *     1) Listen for timer finishing
 *     2) Track current live attackers
 *     3) Tell spawners to stop spawning
 *     4) Enable "Win" overlay
 *     5) Call load next scene
 */


public class LevelController : MonoBehaviour {

    [SerializeField] private GameObject winLabel;
    [SerializeField] private GameObject loseLabel;
    [SerializeField] private float waitToLoad;
    
    
    private int numOfAttackers = 0;
    private bool levelTimerFinished = false;


    private void Start() {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned() {
        numOfAttackers++;
    }
    
    public void AttackerKilled() {
        numOfAttackers--;
        if (numOfAttackers <= 0 && levelTimerFinished) {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition() {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }


    public void handleLoseCondition() {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished() {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners() {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray) {
            spawner.StopSpawning();
        }
    }
}
