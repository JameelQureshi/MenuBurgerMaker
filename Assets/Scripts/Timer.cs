using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityEngine.Advertisements;
public class Timer : MonoBehaviour {
	public static float maxTimer;
	public float degradePerc = .02f;
	public Text timerText;
	public GameObject timeEndPanel;
	public float currentMaxTime;
	private float currentTime;
	public bool isCountingDown;
    public Image fillTimer;

    public AudioSource audioSource;
    public AudioClip audioClip;
	void Awake()
	{
        fillTimer.fillAmount = 1;
		timeEndPanel.SetActive (false);
		StartTimer ();
	}

	void Update()
	{
		if (isCountingDown)
			UpdateCounter();
	}

	public void StartTimer()
	{
		currentTime = currentMaxTime;
		isCountingDown = true;
		DisplayTime();
	}

	public void ResetTimer()
	{
		currentMaxTime -= maxTimer * degradePerc;
		StartTimer();
	}

	void UpdateCounter()
	{
		currentTime -= Time.deltaTime;
		if (currentTime < 0)
		{
			timeEndPanel.SetActive (true);
            audioSource.PlayOneShot(audioClip);
            fillTimer.fillAmount = 0;
			currentTime = 0;
			isCountingDown = false;
			Time.timeScale = 0;
		}
		DisplayTime();
	}

	void DisplayTime()
	{	


        int min;
		float sec;
		float displayTimer = Mathf.Round (currentTime);
        min = (int)(displayTimer / 60);
		sec = (int)(displayTimer % 60);
		if(sec<10)
		timerText.text = "0"+sec;
		else
		timerText.text = ""+sec;
		
	}


}