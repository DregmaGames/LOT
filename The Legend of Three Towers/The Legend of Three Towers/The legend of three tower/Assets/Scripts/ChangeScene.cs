using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour {
	public GameObject Shop = null;
	public GameObject Config = null;

	public void StartGame()
	{
		Application.LoadLevel("Main");
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
	public void StartCredits()
	{
		Application.LoadLevel ("Credits");
	}

}
