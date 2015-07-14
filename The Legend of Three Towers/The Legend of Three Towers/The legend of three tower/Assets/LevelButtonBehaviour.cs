using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelButtonBehaviour : MonoBehaviour {
	public Button btn = null;

	public Image img = null;

	public Sprite enabled_sprite = null;
	public Sprite disabled_sprite = null;

	public int correspondedLevel = 1;
	
	void OnEnable(){

		if (LevelIndexer.instance != null) {
			if(LevelIndexer.instance.level >= correspondedLevel){
				img.sprite = enabled_sprite;
				btn.interactable = true;
			}else{
				img.sprite = disabled_sprite;
				btn.interactable = false;
			}
		}
	}
}
