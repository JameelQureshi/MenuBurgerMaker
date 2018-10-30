using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ItemManagerRoll : MonoBehaviour {
    public int CurrentSeuence;
    int currentIndex;
    public int[] Sequence1;
    public int[] Sequence2;
    public int[] Sequence3;
   

    public Image[] Recipe;
    public Image menu;
    public Sprite[] menuSprites;
    public Sprite[] Recipe1;
    public Sprite[] Recipe2;
    public Sprite[] Recipe3;
    public GameObject successScreen;

    AudioSource audioSource;

    public AudioSource audioSourceClip;
    [Header("Audio Clips")]
    [SerializeField] AudioClip gameWinAudio;
    [SerializeField] AudioClip wrongMove;
    [SerializeField] AudioClip correctMove;
    // Use this for initialization

    public GameObject energyBar;
    [SerializeField] AudioClip energyFill;

	void Start () {
        CurrentSeuence = PlayerPrefs.GetInt("Roll");
        currentIndex = 0;
        for (int i = 0; i < Recipe.Length;i++){
            Recipe[i].gameObject.SetActive(false);
        }
        menu.sprite = menuSprites[CurrentSeuence - 1];
        successScreen.SetActive(false);
        audioSource = GetComponent<AudioSource>();
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        SceneManager.LoadScene(0);
    }

    public void ItemClicked(int id) {
        CheackSequence(id);
	}

    void OnWin(){
        successScreen.SetActive(true);
        audioSource.PlayOneShot(gameWinAudio);
        Destroy(gameObject.GetComponent<Timer>());
        successScreen.SetActive(true);
        Invoke("showFinalScreen", 2f);
    }

    void showFinalScreen()
    {
        successScreen.transform.GetChild(0).gameObject.SetActive(true);
    }


    void FillEnergy(){
        energyBar.SetActive(true);
        audioSourceClip.PlayOneShot(energyFill);
    }

    void CheackSequence(int indexClicked){
        switch(CurrentSeuence){
            
            case 1:
                
                if(Sequence1[currentIndex]==indexClicked){
                    Debug.Log("Correct: "+indexClicked);
                    Recipe[0].gameObject.SetActive(true);
                    Recipe[0].sprite = Recipe1[currentIndex];
                    currentIndex++;

                   
                    audioSourceClip.PlayOneShot(correctMove);
                    if (indexClicked == 9)
                    {
                        FillEnergy();
                    }
                    if(currentIndex == Sequence1.Length){
                        OnWin();
                        Debug.Log("Recipe One Done");
                    }
                }
                else{
                    audioSourceClip.PlayOneShot(wrongMove);
                    Debug.Log("Wrong Item Try Again");
                }
                break;
            case 2:

                if (Sequence2[currentIndex] == indexClicked)
                {
                    Debug.Log("Correct: " + indexClicked);
                    Recipe[1].gameObject.SetActive(true);
                    Recipe[1].sprite = Recipe2[currentIndex];
                    currentIndex++;
                    audioSourceClip.PlayOneShot(correctMove);
                    if (indexClicked == 16)
                    {
                        FillEnergy();
                    }
                    if (currentIndex == Sequence2.Length)
                    {
                        OnWin();
                        Debug.Log("Recipe Two Done");
                    }
                }
                else
                {
                    audioSourceClip.PlayOneShot(wrongMove);
                    Debug.Log("Wrong Item Try Again");
                }
                break;
            case 3:

                if (Sequence3[currentIndex] == indexClicked)
                {
                    Debug.Log("Correct: " + indexClicked);
                    Recipe[2].gameObject.SetActive(true);
                    Recipe[2].sprite = Recipe3[currentIndex];
                    currentIndex++;
                    audioSourceClip.PlayOneShot(correctMove);
                    if (indexClicked == 8)
                    {
                        FillEnergy();
                    }
                    if (currentIndex == Sequence3.Length)
                    {
                        OnWin();
                        Debug.Log("Recipe Three Done");
                    }
                }
                else
                {
                    audioSourceClip.PlayOneShot(wrongMove);
                    Debug.Log("Wrong Item Try Again");
                }
                break;
            
        }
    }
}
