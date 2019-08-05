using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class StarDisplay : MonoBehaviour {

    [SerializeField] private float baseStars = 1000;
    private float stars;
    private Text starText;
   
    
    
    // Start is called before the first frame update
    void Start() {
        stars = baseStars - PlayerPrefsController.GetDifficulty() * 300;
        if (stars <= 0) {
            stars = 0;
        }
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    

    private void UpdateDisplay() {
        starText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount) {
        return stars >= amount;
    }
    
    
    public void AddStars(int amount) {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount) {
        if (stars >= amount) {
            stars -= amount;
            UpdateDisplay();
        }
    }

    
}
