using UnityEngine;
using System.Collections;

public class LevelIndexer : MonoBehaviour {
	//public string era;
	public int level;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}
}
