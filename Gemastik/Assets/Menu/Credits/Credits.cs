using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//Time.timeScale = 0;
			//Application.Quit();
			//Pause();
			BackToMainMenuButton();
		}
	}
	
	public void BackToMainMenuButton(){
		Application.LoadLevel ("Main Menu");
	}
}
