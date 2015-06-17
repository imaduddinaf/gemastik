using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IngameMenu : MonoBehaviour {
	private bool pauseEnabled;
	private bool gameOver;
	private bool congrats;
	//menu
	private float menuWidth;
	private float menuHeight;
	private float finalScore;
	private float screenWidth;
	private float screenHeight;
	//float distanceBetweenMenus;
	public Texture2D ingameMenuBg;
	public Texture2D resume;
	public Texture2D restart;
	public Texture2D quit;
	public Texture2D nextLevel;
	public Texture2D star;
	public Texture2D paused;
	public Texture2D gameover;
	//private float MyGUIAlpha = 0.5f;
	//menu
	public GameObject menu;
	public GameObject pauseMenu;
	public Button[] menu1;
	/*
	public Button resumePauseMenu;
	public Button restartPauseMenu;
	public Button quitPauseMenu;*/
	public GameObject gameOverMenu;
	public Button[] menu2;
	/*
	public Button restartGOMenu;
	public Button quitGOMenu;*/
	public GameObject congratsMenu;
	public Button[] menu3;
	/*
	public Button nextCongratsMenu;
	public Button restartCongratsMenu;
	public Button quitCongratsMenu;*/

	//behaviour

	public void Pause(){
		pauseEnabled = true;
		Time.timeScale = 0;
	}

	public void Resume(){
		pauseEnabled = false;
		Time.timeScale = 1;
	}

	public void GameOver(){
		gameOver = true;
		Time.timeScale = 0;
	}

	public void Congrats(float score){
		congrats = true;
		finalScore = score;
		Time.timeScale = 0;
	}

	public void Quit(){
		MasterData.currentLevel = 0;
		Application.LoadLevel("Main Menu");
	}

	public void NextLevel() {
		MasterData.currentLevel += 1;
		//Debug.Log (MasterData.currentLevel + ".." + MasterData.levelMax);
		if (MasterData.currentLevel > MasterData.levelMax) {
			Application.LoadLevel ("World Map");
		} else {
			Application.LoadLevel ("Level " + MasterData.currentLevel);
		}
	}

	public void Restart(){		
		Resume();
		Application.LoadLevel(Application.loadedLevel);
	}
	// Use this for initialization
	void Start () {
		menuWidth = Screen.width * 0.7f;
		menuHeight = Screen.height * 0.9f;
		pauseEnabled = false;
		gameOver = false;
		congrats = false;
		finalScore = 0;
		//menu
		menu = GameObject.Find ("Menu");
		pauseMenu = GameObject.Find ("Pause");
		menu1 = pauseMenu.GetComponents<Button> ();
		/*
		resumePauseMenu = (Button) GameObject.Find ("Resume");
		restartPauseMenu = (Button) GameObject.Find ("Restart");
		quitPauseMenu = (Button) GameObject.Find ("Quit");*/
		gameOverMenu = GameObject.Find ("GameOver");
		menu2 = gameOverMenu.GetComponents<Button> ();
		/*
		restartGOMenu = (Button) GameObject.Find ("Restart1");
		quitGOMenu = (Button) GameObject.Find ("Quit1");*/
		congratsMenu = GameObject.Find ("Congrats");
		menu3 = congratsMenu.GetComponents<Button> ();
		/*
		extCongratsMenu = (Button) GameObject.Find ("Next");
		restartCongratsMenu = (Button) GameObject.Find ("Restart2");
		quitCongratsMenu = (Button) GameObject.Find ("Quit2");*/
		pauseMenu.SetActive(false);
		gameOverMenu.SetActive(false);
		congratsMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//Pause ();
		/*if (!pauseEnabled && Input.GetKeyDown (KeyCode.Escape)) {
			//Time.timeScale = 0;
			//Application.Quit();
			Pause();
		}*/
		if (Input.GetKeyDown (KeyCode.Backspace) || Input.GetKeyDown (KeyCode.Escape)) {
			if(pauseEnabled && !gameOver && !congrats) {
				Resume();
			}
			else if(!pauseEnabled && !gameOver && !congrats) {
				Pause();
			}
		}
		//menu
		if (pauseEnabled) {
			pauseMenu.SetActive (true);
			gameOverMenu.SetActive (false);
			congratsMenu.SetActive (false);
		} else if (gameOver) {
			pauseMenu.SetActive (false);
			gameOverMenu.SetActive (true);
			congratsMenu.SetActive (false);
		} else if (congrats) {
			pauseMenu.SetActive (false);
			gameOverMenu.SetActive (false);
			congratsMenu.SetActive (true);
		} else {
			pauseMenu.SetActive(false);
			gameOverMenu.SetActive(false);
			congratsMenu.SetActive(false);
		}
	}

	void OnGUI(){

		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		float distanceBetweenMenus = menuHeight * 0.05f;
		GUI.skin.box.fontSize=50;
		GUI.skin.box.wordWrap=false;
		GUI.skin.button.fontSize=50;
		GUI.skin.button.wordWrap=false;
		GUI.depth = -1;
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		//distanceBetweenMenus = menuHeight * 0.05f;
		//GUI.skin.button.onActive.background = resume;

		//menu pause
		if (pauseEnabled) {
			
			//redup is good
			//GUI.Box (new Rect (0, 0, screenWidth, screenHeight), "");
			//tulisan pause
			GUI.DrawTexture (new Rect ((screenWidth * 0.5f) - ((screenWidth * 0.3f) * 0.5f), (screenHeight * 0.2f), screenWidth * 0.3f, screenHeight * 0.12f), paused);
			//box
			/*//GUI.Box (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.35f), (screenHeight * 0.5f) - (screenHeight * 0.45f), menuWidth, menuHeight), "");
			//GUI.DrawTexture (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.35f), (screenHeight * 0.5f) - (screenHeight * 0.45f), menuWidth, menuHeight), ingameMenuBg, ScaleMode.ScaleToFit, true);

			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (menuWidth * 0.2f * 0.5f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.2f, menuHeight * 0.2f), resume)) {
				Debug.Log ("Resume");
				Resume();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (menuWidth * 0.2f * 2.0f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.2f, menuHeight * 0.2f), restart)) {
				Debug.Log ("Restart");
				Restart();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) + (menuWidth * 0.2f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.2f, menuHeight * 0.2f), quit)) {
				Debug.Log ("Quit");
				Quit ();
			}*/
		}
		//menu gameover
		if (gameOver) {
			//redup is good
			//GUI.Box (new Rect (0, 0, screenWidth, screenHeight), "");
			//tulisan gameover
			GUI.DrawTexture (new Rect ((screenWidth * 0.5f) - ((screenWidth * 0.5f) * 0.5f), (screenHeight * 0.2f), screenWidth * 0.5f, screenHeight * 0.12f), gameover);
			//box
			/*//GUI.Box (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f), (screenHeight * 0.5f) - (screenHeight * 0.35f), menuWidth, menuHeight), "");
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (menuWidth * 0.2f * 2.0f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.2f, menuHeight * 0.2f), restart)) {
				Debug.Log ("Restart");
				Restart();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) + (menuWidth * 0.2f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.15f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.2f, menuHeight * 0.2f), quit)) {
				Debug.Log ("Quit");
				Quit ();
			}*/
		}
		//menu win-congrats
		if (congrats) {
			//redup is good
			//GUI.Box (new Rect (0, 0, screenWidth, screenHeight), "");
			//GUI.Box (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f), (screenHeight * 0.5f) - (screenHeight * 0.35f), menuWidth, menuHeight), "congratulations!!");
			//GUI.DrawTexture (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.35f), (screenHeight * 0.5f) - (screenHeight * 0.45f), menuWidth, menuHeight), ingameMenuBg, ScaleMode.ScaleToFit, true);
			float tmp = MasterData.ChangeHighScore(Application.loadedLevelName, finalScore);
			//final
			//finalscore
			if(finalScore < 0.34){
				//Debug.Log("Bintang 1");
				//left
				GUI.DrawTexture (new Rect ((screenWidth * 0.5f) - (menuWidth * 0.125f * 1.4f), (screenHeight * 0.5f) - (menuHeight * 0.155f * 0.6f), menuWidth * 0.125f, menuHeight * 0.155f), star);
			}
			else if (finalScore < 0.76) {
				//Debug.Log("Bintang 2");
				//left
				GUI.DrawTexture (new Rect ((screenWidth * 0.5f) - (menuWidth * 0.125f * 1.4f), (screenHeight * 0.5f) - (menuHeight * 0.155f * 0.6f), menuWidth * 0.125f, menuHeight * 0.155f), star);
				//mid
				GUI.DrawTexture (new Rect ((screenWidth * 0.5f) - (menuWidth * 0.125f * 0.5f), (screenHeight * 0.5f) - (menuHeight * 0.155f * 0.6f), menuWidth * 0.125f, menuHeight * 0.155f), star);
			}
			else if (finalScore <= 1) {
				//Debug.Log("Bintang 3");
				//left
				GUI.DrawTexture (new Rect ((screenWidth * 0.5f) - (menuWidth * 0.125f * 1.4f), (screenHeight * 0.5f) - (menuHeight * 0.155f * 0.6f), menuWidth * 0.125f, menuHeight * 0.155f), star);
				//mid
				GUI.DrawTexture (new Rect ((screenWidth * 0.5f) - (menuWidth * 0.125f * 0.5f), (screenHeight * 0.5f) - (menuHeight * 0.155f * 0.6f), menuWidth * 0.125f, menuHeight * 0.155f), star);
				//right
				GUI.DrawTexture (new Rect ((screenWidth * 0.5f) + (menuWidth * 0.125f * 0.4f), (screenHeight * 0.5f) - (menuHeight * 0.155f * 0.6f), menuWidth * 0.125f, menuHeight * 0.155f), star);
			}
			//
			/*if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f ), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.25f) + (distanceBetweenMenus + (menuHeight * 0.3f)), menuWidth * 0.15f, menuHeight * 0.15f), restart)) {
				Debug.Log ("Restart");
				Restart();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.075f ), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.25f) + (distanceBetweenMenus + (menuHeight * 0.2f)), menuWidth * 0.2f, menuHeight * 0.2f), nextLevel)) {
				Debug.Log ("Next Level");
				NextLevel();
			}
			if (GUI.Button (new Rect ((screenWidth * 0.65f), (screenHeight * 0.5f) - (screenHeight * 0.35f) + (menuHeight * 0.25f) + (distanceBetweenMenus + (menuHeight * 0.3f)), menuWidth * 0.15f, menuHeight * 0.15f), quit)) {
				Debug.Log ("Quit");
				Quit ();
			}*/
		}
	}
}
		