using UnityEngine;
using System.Collections;

public class SplashScript : MonoBehaviour 
{
	public Texture[] logos; 
	int logoNum = 0; 
	
	public string sceneAfterSplash;
	
	float fadeSpeed = 1.5f; 
	float alpha = 0; 
	
	float timerPrev = 1;
	float timerLogoOn = 2.5f; 
	float savedTimerLogoOn; 
	
	bool finishWithLogo = true; 
	bool endIntro = false; 
	
		
	void Start ()
	{
		if (fadeSpeed == 0)
			fadeSpeed = 1;
		if (fadeSpeed < 0) 
			fadeSpeed *= -1;
		
		savedTimerLogoOn = timerLogoOn;
	}
	
	void OnGUI()
	{
		GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,alpha); 
		
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), logos[logoNum], ScaleMode.ScaleToFit);		
	}
	

	void Update () {
		
		if (timerPrev > 0) 
			timerPrev -= Time.deltaTime;
		else
			timerPrev= 0;
		
		if (timerPrev == 0 && !endIntro) 
		{
			alpha += Time.deltaTime * fadeSpeed; 
			alpha = Mathf.Clamp01(alpha); 
			if (alpha >= 1) 
			{
				timerLogoOn -= Time.deltaTime; 
				if (timerLogoOn <= 0) 
				{
					timerLogoOn = savedTimerLogoOn; 
					fadeSpeed *= -1; 
					if (finishWithLogo && logoNum == logos.Length-1) 
						endIntro = true; 
				}				
			}
			if (alpha <= 0) 
			{
				fadeSpeed *= -1; 
				if (logoNum == logos.Length-1) 
				{
					endIntro = true; 
					alpha = 0; 
				}
				else 
					logoNum++; 
				
			}
		}
		
		if (endIntro) 
		{
			Application.LoadLevel(sceneAfterSplash);
		}
	}
	
}
