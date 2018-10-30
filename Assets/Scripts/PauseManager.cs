using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour {
    public GameObject pauseScreen;
	// Use this for initialization
	void Start () {
        pauseScreen.SetActive(false);
	}

    public void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
    public void Restart(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
