using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour {
	public GameObject Shop = null;
	public GameObject Config = null;
	public GameObject SelectLevel = null;
	public GameObject Paused = null;
	public GameObject Tutorial = null;
	public void Menu()
	{
		Application.LoadLevel ("Menu");
	}
	public void StartGame()
	{
		Application.LoadLevel("Main");
	}
	public void LoadLevel(int l){
		Application.LoadLevel (1);
	}
	public void EndGame()
	{
		Application.Quit ();
	}
	public void toggleShop()
	{
		if (Shop)
			Shop.SetActive (!Shop.activeSelf);
	}
	public void toggleConfig()
	{
		if (Config)
			Config.SetActive (!Config.activeSelf);
	}
	public void setPause(bool p)
	{
		
		if(GameManager._gameState != GameManager.State.ENDED){
			if(p){
				Paused.SetActive(true);
				Time.timeScale = 0;
				if(GameManager._gameState == GameManager.State.STARTED)
					GameManager._gameState = GameManager.State.PAUSED;
			}else{
				Paused.SetActive(false);
				Time.timeScale = 1;
				if(GameManager._gameState == GameManager.State.PAUSED)
					GameManager._gameState = GameManager.State.STARTED;
			}
		}
			
	}
	public void toggleTutorial()
	{
		if (Tutorial)
			Tutorial.SetActive (!Tutorial.activeSelf);
		Time.timeScale = 0;
		
	}
	public void toggleSelectLevel(){
		if (SelectLevel)
			SelectLevel.SetActive (!SelectLevel.activeSelf);
	}

	public void StartCredits()
	{
		Application.LoadLevel ("Credits");
	}

	public void setLevel(int l){
		if (LevelIndexer.instance != null) {
			LevelIndexer.instance.currentLevel = l;
			StartGame();
		}
	}
	
	public void shareOnSocial(){
		#if UNITY_ANDROID
		if(Application.isMobilePlatform){
			AndroidJavaClass plugin = new AndroidJavaClass("com.dregmaGames.plugin.SharePlugin");
			plugin.CallStatic("shareText", "The Legend of Three Towers" , "Acabo de superar el nivel " + LevelIndexer.instance.currentLevel.ToString());
		}
		#endif
		Debug.Log ("Share Sent!");
	}

}
