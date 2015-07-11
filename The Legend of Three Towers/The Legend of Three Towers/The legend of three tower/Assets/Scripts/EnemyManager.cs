using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public Transform[] spawnPoints;
	public GameObject[] enemiesPrefabs;
	
	public float timeInterval = 1;
	private float timer;

	private int minSpawn  = 1;
	public bool canSpawn0 = false;
	// Use this for initialization
	void Start () {
		timer = timeInterval;

		if (canSpawn0)
			minSpawn = 0;
		else
			minSpawn = 1;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeInterval) {
			timer = 0;
			SpawnEnemies();
		}
	}

	void SpawnEnemies(){
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
