using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ItemManager : MonoBehaviour {
    public int CurrentSeuence;
    int currentIndex;
    public int[] Sequence1;
    public int[] Sequence2;
    public int[] Sequence3;
    public int[] Sequence4;
    public int[] Sequence5;
    public int[] Sequence6;

    public Image[] Recipe;
    public Image menu;
    public Sprite[] menuSprites;
    public Sprite[] Recipe1;
    public Sprite[] Recipe2;
    public Sprite[] Recipe3;
    public Sprite[] Recipe4;
    public Sprite[] Recipe5;
    public Sprite[] Recipe6;
    public GameObject successScreen;
    AudioSource audioSource;

    public AudioSource audioSourceClip;
    [Header("Audio Clips")]
    [SerializeField] AudioClip gameWinAudio;
    [SerializeField] AudioClip wrongMove;
    [SerializeField] AudioClip correctMove;

    [SerializeField] GameObject[] menuItems;

    public GameObject energyBar;
    [SerializeField] AudioClip energyFill;

	// Use this for initialization
	void Start () {
        CurrentSeuence = PlayerPrefs.GetInt("Burger");
        currentIndex = 0;
        for (int i = 0; i < Recipe.Length;i++){
            Recipe[i].gameObject.SetActive(false);
        }
        menu.sprite = menuSprites[CurrentSeuence - 1];
        successScreen.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        switch(CurrentSeuence){
            case 1:
                menuItems[1].SetActive(false);
                menuItems[4].SetActive(false);
                break;

            case 2:
                menuItems[1].SetActive(false);
                menuItems[4].SetActive(false);
                break;

            case 3:
                menuItems[0].SetActive(false);
                menuItems[1].SetActive(false);
                break;

            case 4:
                menuItems[2].SetActive(false);
                menuItems[4].SetActive(false);
                break;

            case 5:
                menuItems[0].SetActive(false);
                menuItems[1].SetActive(false);
                break;

            case 6:
                menuItems[2].SetActive(false);
                menuItems[4].SetActive(false);
                break;
        }

	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        SceneManager.LoadScene(0);
    }

    public void ItemClicked(int id) {
        CheackSequence(id);
	}
    void FillEnergy()
    {
        energyBar.SetActive(true);
        audioSourceClip.PlayOneShot(energyFill);
    }
    void OnWin(){
        audioSource.Stop();
        audioSource.PlayOneShot(gameWinAudio);
        Destroy( gameObject.GetComponent<Timer>());
        successScreen.SetActive(true);
        Invoke("showFinalScreen",2f);
    }

    void showFinalScreen(){
        successScreen.transform.GetChild(0).gameObject.SetActive(true);
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

                    if (indexClicked == 3)
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

                    if (indexClicked == 3)
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
                    if (indexClicked == 11)
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
            case 4:

                if (Sequence4[currentIndex] == indexClicked)
                {
                    Debug.Log("Correct4: " + indexClicked);
                    Recipe[3].gameObject.SetActive(true);
                    Recipe[3].sprite = Recipe4[currentIndex];
                    currentIndex++;
                    audioSourceClip.PlayOneShot(correctMove);
                    if (indexClicked == 10)
                    {
                        FillEnergy();
                    }
                    if (currentIndex == Sequence4.Length)
                    {
                        OnWin();
                        Debug.Log("Recipe One Done");
                    }
                }
                else
                {
                    audioSourceClip.PlayOneShot(wrongMove);
                    Debug.Log("Wrong Item Try Again");
                }
                break;
            case 5:

                if (Sequence5[currentIndex] == indexClicked)
                {
                    Debug.Log("Correct: " + indexClicked);
                    Recipe[4].gameObject.SetActive(true);
                    Recipe[4].sprite = Recipe5[currentIndex];
                    currentIndex++;
                    audioSourceClip.PlayOneShot(correctMove);
                    if (indexClicked == 13)
                    {
                        FillEnergy();
                    }
                    if (currentIndex == Sequence5.Length)
                    {
                        OnWin();
                        Debug.Log("Recipe One Done");
                    }
                }
                else
                {
                    audioSourceClip.PlayOneShot(wrongMove);

                    Debug.Log("Wrong Item Try Again");
                }
                break;

            case 6:

                if (Sequence6[currentIndex] == indexClicked)
                {
                    Debug.Log("Correct: " + indexClicked);
                    Recipe[5].gameObject.SetActive(true);
                    Recipe[5].sprite = Recipe6[currentIndex];
                    currentIndex++;
                    audioSourceClip.PlayOneShot(correctMove);
                    if (indexClicked == 12)
                    {
                        FillEnergy();
                    }
                    if (currentIndex == Sequence6.Length)
                    {
                        OnWin();
                        Debug.Log("Recipe One Done");
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
