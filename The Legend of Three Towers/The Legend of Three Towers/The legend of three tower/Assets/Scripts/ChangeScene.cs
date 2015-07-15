using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour {
	public GameObject Shop = null;
	public GameObject Config = null;
	public GameObject SelectLevel = null;
	public GameObject Paused = null;

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
	public void togglePaused()
	{
		if (Paused)
			Paused.SetActive (!Paused.activeSelf);
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

}
