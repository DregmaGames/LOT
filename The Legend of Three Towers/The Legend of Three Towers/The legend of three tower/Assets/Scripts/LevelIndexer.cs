using UnityEngine;
using System.Collections;

public class LevelIndexer : MonoBehaviour {
	//public string era;
	public int level = 1;	// Default level... 1 :)
	public int currentLevel = 1;
	public static LevelIndexer instance = null;
	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (transform.gameObject);
			LoadData();
		}
	}

	public void addLevel(int c){
		level += c;
	}

	void LoadData(){
		if (PlayerPrefs.HasKey ("Levels")) {
			this.level = PlayerPrefs.GetInt ("Levels");
		} else {
			this.level = 1;
			PlayerPrefs.SetInt("Levels", 1);
			PlayerPrefs.Save();
		}
	}

	void OnApplicationQuit(){
		PlayerPrefs.SetInt ("Levels", this.level);
		PlayerPrefs.Save ();
	}


}
