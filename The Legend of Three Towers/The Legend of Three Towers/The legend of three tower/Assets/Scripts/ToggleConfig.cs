using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(Toggle))]
public class ToggleConfig : MonoBehaviour {

		public Sprite Inactive = null;
		
		private Toggle _Toggle = null;
		private Image _Background = null;
		private Sprite _BackgroundActive = null;
		
		void Awake()
		{
			_Toggle = GetComponent<Toggle>();
			_Background = transform.GetComponentInChildren<Image>();
			_BackgroundActive = _Background.sprite;
		}
		
		public void Toggle()
		{
			if (_Toggle.isOn)
				_Background.sprite = _BackgroundActive;
			else
				_Background.sprite = Inactive;
		}
}