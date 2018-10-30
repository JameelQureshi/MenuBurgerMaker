using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FoodSelection : MonoBehaviour {

    [SerializeField] GameObject mainScreen;
    [SerializeField] GameObject typeSelect;
    [SerializeField] GameObject burgerSelect;
    [SerializeField] GameObject rollSelect;
    public AudioSource audioSource;
    public AudioClip click;


    private void Start()
    {
        mainScreen.SetActive(true);
        typeSelect.SetActive(false);
        burgerSelect.SetActive(false);
        rollSelect.SetActive(false);
    }

    public void Play()
    {
        audioSource.PlayOneShot(click);
        mainScreen.SetActive(false);
        typeSelect.SetActive(true);
    }

    public void SelectType(int index){
        audioSource.PlayOneShot(click);
        if(index==1){
            burgerSelect.SetActive(true);
        }
        if(index==2){
            rollSelect.SetActive(true);
        }
    }
    public void SlectBurger (int index) {
        audioSource.PlayOneShot(click);
        PlayerPrefs.SetInt("Burger",index);
        SceneManager.LoadScene(2);
	}
    public void SlectRoll(int index)
    {
        audioSource.PlayOneShot(click);
        PlayerPrefs.SetInt("Roll", index);
        SceneManager.LoadScene(3);
    }
}
