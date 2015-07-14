using UnityEngine;
using System.Collections;

public class DataSpawner : MonoBehaviour {
	public GameObject prefab = null;
	// Use this for initialization
	void Awake () {
		Time.timeScale = 1;
		if (LevelIndexer.instance == null) {
			Instantiate(prefab);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
