using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	private bool quit;
	//menu
	private float menuWidth;
	private float menuHeight;
	private GameObject sound;
	private Image soundImg;
	public Sprite mute;
	public Sprite unmute;
	// Use this for initialization
	void Start () {
		menuWidth = Screen.width * 0.5f;
		menuHeight = Screen.height * 0.5f;
		quit = false;
		sound = GameObject.Find ("Sound");
		soundImg = sound.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//Time.timeScale = 0;
			//Application.Quit();
			quit = true;
			//Pause();
		}
		
		if (AudioListener.volume == 0.0) {//mute
			soundImg.sprite = mute;
		} else {//unmute
			soundImg.sprite = unmute;
		}
	
	}

	void Quit(){
		Application.Quit ();
	}

	public void OnClickPlay(){
		Application.LoadLevel ("World Map");
		MasterData.WriteToFile ();
	}

	public void OnClickDie(){
		quit = true;
	}

	public void OnClickCredits(){
		Application.LoadLevel ("Credits");		
	}

	public void OnClickOptions(){
		Application.LoadLevel ("Options");	
	}

	public void OnClickMuteUnmute(){
		//Debug.Log (sound.name);
		if (MasterData.volume == 0.0) {//unmute
			MasterData.volume = 1.0f;
			AudioListener.volume = 1.0f;
		} else {//mute
			MasterData.volume = 0.0f;
			AudioListener.volume = 0.0f;
		}
		MasterData.WriteToFile ();
	}

	void OnGUI(){
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		//float distanceBetweenMenus = menuHeight * 0.05f;
		//menu pause
		if (quit) {
			GUI.Box (new Rect ((screenWidth * 0.5f) - (screenWidth * 0.25f), (screenHeight * 0.5f) - (screenHeight * 0.5f * 0.25f), menuWidth, menuHeight * 0.5f), "Are you sure?");
			if (GUI.Button (new Rect ((screenWidth * 0.5f) - (menuWidth * 0.3f * 1.5f), (screenHeight * 0.5f), menuWidth * 0.3f, menuHeight * 0.2f), "Cancel")) {
				//Debug.Log ("Cancel Quit");
				quit = false;
			}
			if (GUI.Button (new Rect ((screenWidth * 0.5f) + (menuWidth * 0.3f * 0.5f), (screenHeight * 0.5f), menuWidth * 0.3f, menuHeight * 0.2f), "Quit")) {
				//Debug.Log ("Quit");
				Quit ();
			}
		}
	}
}
