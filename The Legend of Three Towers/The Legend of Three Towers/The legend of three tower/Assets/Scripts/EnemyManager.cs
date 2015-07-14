using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public static EnemyManager instance = null;
	public Transform[] spawnPoints;
	public GameObject[] enemiesPrefabs;
	
	public float timeInterval = 1;
	private float timer;

	private int minSpawn  = 1;
	public bool canSpawn0 = false;


	public int EnemiesPerLevel = 5;

	// Use this for initialization
	void Awake(){
		instance = this;	// Singleton... Why So Serious?!
	}

	void Start () {
		timer = timeInterval;

		if (canSpawn0)
			minSpawn = 0;
		else
			minSpawn = 1;

		if (!LevelIndexer.instance) {
			enabled = false;
			Debug.Log("We have not LevelIndexer");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager._gameState == GameManager.State.STARTED)
			timer += Time.deltaTime;

		if (timer >= timeInterval) {
			timer = 0;
			SpawnEnemies();
		}

	}


	void SpawnEnemies(){

		// We should check if we can spawn more than 1... But, anyways... Don't affect to our game at all.. GL HF.

		int Q = Random.Range (minSpawn, 4);
		switch (Q) {
			case 0:
				return;
			case 1: 
			Vector3 sPos = spawnPoints[getPosition()].position;
			GameObject go = ObjectPool.instance.GetObjectForType(enemiesPrefabs[Random.Range(0,enemiesPrefabs.Length)].name);
			go.transform.position = sPos;
			break;

			case 2:
			int s1 = getPosition();
			int s2 = getPosition(s1);

			Vector3 pos = spawnPoints[s1].position;
			GameObject go1 = ObjectPool.instance.GetObjectForType(enemiesPrefabs[Random.Range(0,enemiesPrefabs.Length)].name);
			go1.transform.position = pos;

			pos = spawnPoints[s2].position;
			go1 = ObjectPool.instance.GetObjectForType(enemiesPrefabs[Random.Range(0,enemiesPrefabs.Length)].name);
			go1.transform.position = pos;
			break;

			case 3:
			GameObject go2 = ObjectPool.instance.GetObjectForType(enemiesPrefabs[Random.Range(0,enemiesPrefabs.Length)].name);
			go2.transform.position = spawnPoints[0].position;

			go2 = ObjectPool.instance.GetObjectForType(enemiesPrefabs[Random.Range(0,enemiesPrefabs.Length)].name);
			go2.transform.position = spawnPoints[1].position;

			go2 = ObjectPool.instance.GetObjectForType(enemiesPrefabs[Random.Range(0,enemiesPrefabs.Length)].name);
			go2.transform.position = spawnPoints[2].position;
			break;
		}
	}

	int getPosition(int Exception = -1){
		if (Exception != -1) {
			int p = Exception;
			int r = p;
			do{
				r = Random.Range (0, spawnPoints.Length);
			}while( p == r);

			return r;
		} else {
			return Random.Range(0, spawnPoints.Length);
		}
	}
}
