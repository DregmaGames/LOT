using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackArrow : MonoBehaviour {
	public string collideTag = "";
//	private Vector3 Direction = Vector3.zero;
	public float speed = 5f;

	private float MaxAliveTime = 4f;
	private float counter = 0;

	// Use this for initialization
	void Start () {
	}

	void OnEnable() {
		counter = 0;
		//Direction = Vector3.zero;
		OnInitArrow ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == collideTag) {
			GameManager.addScore(col.GetComponent<EnemyMove>().scoreOnDie);
			ObjectPool.instance.PoolObject (col.gameObject);
			ObjectPool.instance.PoolObject (this.gameObject);
			GameManager.instance.mobPlusPlus();
		}

	}

	void Update (){
		counter += Time.deltaTime;
		transform.Translate (transform.right * Time.deltaTime * speed);

		if (counter >= MaxAliveTime) {
			ObjectPool.instance.PoolObject(this.gameObject);
		}
	}

	void OnInitArrow(){
		float random = Random.Range (0f, 1f);
		if (random <= 0.5f) {
			float angulo = Random.Range (-8f, 8f);
			Vector3 euler = transform.rotation.eulerAngles;
			euler.z = angulo;

			transform.rotation = Quaternion.Euler ( euler );

		}
	}
}
