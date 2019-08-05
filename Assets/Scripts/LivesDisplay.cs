using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LivesDisplay : MonoBehaviour {

    [SerializeField] private float baseLives = 3f;
    [SerializeField] private int damage = 1;
    private float lives;
    private Text livesText;
    
    
    // Start is called before the first frame update
    void Start() {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    void UpdateDisplay() {
        livesText.text = lives.ToString();
    }


    public void TakeLife() {
        lives -= damage;
        UpdateDisplay();

        if (lives <= 0) {
            FindObjectOfType<LevelController>().handleLoseCondition();
        }
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
