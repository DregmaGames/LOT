using UnityEngine;
using System.Collections;

public class Buttom : MonoBehaviour {
	public ButtomAction action;
	public Vector3 scaleOut;
	public float ScaleOver = 1.2f;
	public bool overButton=false;
	public float easeOver=3;
	void Start(){
		scaleOut = transform.localScale;
	}
	void Update(){
		if (overButton) {
			transform.localScale = Vector3.Lerp (transform.localScale, scaleOut*ScaleOver, Time.deltaTime * easeOver);
		} else {
			transform.localScale=Vector3.Lerp(transform.localScale,scaleOut,Time.deltaTime*easeOver);		
		}
	}
	void OnMouseEnter(){
		Debug.Log ("enter");
		overButton = true;
	}
	void OnMouseExit(){
		Debug.Log ("Exit");
		overButton = false;
	}
	void OnMouseDown(){
		action.ExecuteAction();
	}
}
