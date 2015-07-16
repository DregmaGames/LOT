using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public static State 	  _gameState = State.STARTED;
	public ChangeScene tools = null;
	private int score = 0;

	private int mobToLvlUp = 0;
	private int currentMob = 0;

	public  int SpawnPerLevel = 20;

	public int HP = 10;
	private int currentHP;

	[Header("GUI")]
	public Slider hpSlider = null;
	public Slider levelProgressionSlider = null;

	public GameObject resultScreen = null;
	public Text		  messageText = null;

	public enum State {
		PAUSED,
		STARTED,
		ENDED
	};


	// Use this for initialization
	void Start () {
		_gameState = State.STARTED;

		currentHP = HP;
	}

	void Awake(){
		instance = this;

		if (LevelIndexer.instance == null) {

			Application.LoadLevel(1);	// Mando al menu
			return;
		}

		mobToLvlUp = LevelIndexer.instance.currentLevel * SpawnPerLevel;
		currentMob = 0;
		Time.timeScale = 1;
	}

	public void mobPlusPlus(){
		currentMob++;
	}

	public void setHP(int c){
		currentHP += c;
	}

	void Update(){

		UpdateGraphics ();

		if (_gameState != State.ENDED) {
			if ( weWin() ) {
				OnWinCondition ();
			}

			if ( weLose() ) {
				OnLoseCondition ();
			}

			if (Input.GetKeyDown(KeyCode.Escape)){
				tools.setPause(true);
			}

		}
	}

	void UpdateGraphics(){
		if (hpSlider != null) {
			float v = (float)currentHP / (float) HP;
			hpSlider.value = v;
		}
		if (levelProgressionSlider != null) {
			float v = (float) currentMob / (float) mobToLvlUp;
			levelProgressionSlider.value = v;
		}
	}

	// -------------------------------------
	bool weWin(){
		if (_gameState == State.STARTED) {
			return currentMob >= mobToLvlUp;
		}

		return false;
	}

	void OnWinCondition(){
		if (_gameState == State.STARTED) {
			Time.timeScale = 0;
			if( LevelIndexer.instance.level == LevelIndexer.instance.currentLevel)
				LevelIndexer.instance.level += 1;
			_gameState = State.ENDED;

			messageText.text = "You Win!";
			resultScreen.SetActive(true);

		}
	}
	// -------------------------------------
	bool weLose(){

		if (_gameState == State.STARTED) {
			return currentHP <= 0;
		}

		return false;
	}

	void OnLoseCondition(){
		if (_gameState == State.STARTED) {
			Debug.Log("YOU LOSE");
			Time.timeScale = 0;
			_gameState = State.ENDED;

			messageText.text = "You Lose!";
			resultScreen.SetActive(true);
		}
	}
	
	// -------------------------------------
	public static void addScore(int _score){
		instance.score += _score;
	}
	// -------------------------------------
	public static void setState(State s){
		_gameState = s;
	}
	// -------------------------------------

	#if UNITY_ANDROID
		void callFromThePlugin(string s){
			Debug.Log (s);
		}
	#endif
}
