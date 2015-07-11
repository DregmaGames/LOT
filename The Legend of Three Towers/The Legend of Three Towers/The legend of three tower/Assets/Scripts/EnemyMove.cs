using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	//Enemy Move Left
	public Vector3 moveSpeed;

	private float MaxAliveTime = 30f;
	private float counter = 0;

	public int scoreOnDie = 100;
	void Start () {
	
	}

	void OnEnable(){
		counter = 0;
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "WallCollider")
		{
			//Destroy(gameObject);
			ObjectPool.instance.PoolObject(this.gameObject);
		}

	}

	void Update () {

		transform.position -= moveSpeed;
		counter += Time.deltaTime;
		if (counter >= MaxAliveTime) {
			ObjectPool.instance.PoolObject(this.gameObject);
		}
	}
}
