using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(Toggle))]
public class ToggleConfig : MonoBehaviour {

		public Sprite Inactive = null;
		
		private Toggle Togglee = null;
		private Image Background_img = null;
		private Sprite BackgroundActive_spr = null;
		
		void Awake()
		{
			Togglee = GetComponent<Toggle>();
			Background_img = transform.GetComponentInChildren<Image>();
			BackgroundActive_spr = Background_img.sprite;
		}
		
		public void Toggle()
		{
			if (Togglee.isOn)
				Background_img.sprite = BackgroundActive_spr;
			else
				Background_img.sprite = Inactive;
		}
}