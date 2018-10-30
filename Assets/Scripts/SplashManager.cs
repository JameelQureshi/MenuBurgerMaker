using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LoadNext",4);
	}
	
	// Update is called once per frame
	void LoadNext () {
        SceneManager.LoadScene(1);
	}
}
