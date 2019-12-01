using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] int timeToWait = 4;

    // Start is called before the first frame update
    void Start() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0) {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime() {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }


    public void LoadMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }


    public void LoadOptionsScreen() {

        SceneManager.LoadScene("Options Screen");
    }
    
    
    
    public void RestartScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    
    public void LoadNextScene() {
        if (currentSceneIndex == 4) {
            SceneManager.LoadScene(1);
        } else {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

    }


    public void LoadLose() {
        SceneManager.LoadScene("Lose Screen");
    }

    public void QuitGame() {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
