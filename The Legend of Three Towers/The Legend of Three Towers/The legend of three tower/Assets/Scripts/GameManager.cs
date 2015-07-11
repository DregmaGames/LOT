using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public static State 	  _gameState = State.STARTED;
	private int score = 0;

	public enum State {
		PAUSED,
		STARTED,
		END
	};


	// Use this for initialization
	void Start () {

		if (instance == null) {
			instance = this;
		}

		_gameState = State.STARTED;

		#if UNITY_ANDROID
			if (Application.isMobilePlatform) {
				callPlugin();
			}
		#endif
	}

	public static void addScore(int _score){
		instance.score += _score;
	}

	void callPlugin(){
	#if UNITY_ANDROID
		using (AndroidJavaClass ajc = new AndroidJavaClass("com.dregmagames.plugin.Main")) {
			ajc.CallStatic("Test");
		}
	#endif
	}

	#if UNITY_ANDROID
		void callFromThePlugin(string s){
			Debug.Log (s);
		}
	#endif
}
