using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterController : MonoBehaviour {
	public GameObject ArrowPrefab;
	public AudioSource clip;
	void Start(){
	}

	void Update(){
	
		if (GameManager._gameState == GameManager.State.STARTED && Input.GetMouseButtonDown(0)) {

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit && hit.collider.gameObject.tag.Equals("SpawnPoint"))	
					transform.position = hit.transform.position;
			else {
				GameObject go = ObjectPool.instance.GetObjectForType("arrow");
				go.transform.position = this.transform.position;
				clip.Play();
			}
			
		}

			
	}
	

}
