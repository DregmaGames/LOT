using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class Shop_Button : MonoBehaviour {

	public GameObject prefab_image;
	public GameObject Panel;
	int max = 9;
	private List <GameObject> Barritas = new List<GameObject>();
	public GameObject text;
	public int MaxMoney = 9999;
	void Start () 
	{
	
	}
	

	public void Button()
	{
		if (Barritas.Count == max)
			return;
		GameObject aux = Instantiate (prefab_image);
		aux.transform.SetParent(Panel.transform, false);
		Barritas.Add (aux);
	}
}
