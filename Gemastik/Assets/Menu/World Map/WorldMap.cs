using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour {
	
	public Text version;
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
		//Debug.Log (MasterData.GameVersion);
	}

	public void BackToMainMenuButton(){
		Application.LoadLevel ("Main Menu");
	}
	//level picker
	public void Tutorial(){
		MasterData.currentLevel = 0;
		Application.LoadLevel ("Tutorial");
	}
	public void Level1(){
		MasterData.currentLevel = 1;
		Application.LoadLevel ("Level 1");
	}
	public void Level2(){
		MasterData.currentLevel = 2;
		Application.LoadLevel ("Level 2");
	}
	public void Level3(){
		MasterData.currentLevel = 3;
		Application.LoadLevel ("Level 3");
	}
	public void level4(){
		MasterData.currentLevel = 4;
		Application.LoadLevel ("Level 4");
	}
	public void level5(){
		MasterData.currentLevel = 5;
		Application.LoadLevel ("Level 5");
	}
	public void level6(){
		MasterData.currentLevel = 6;
		Application.LoadLevel ("Level 6");
	}
	public void level7(){
		MasterData.currentLevel = 7;
		Application.LoadLevel ("Level 7");
	}
	public void level8(){
		MasterData.currentLevel = 8;
		Application.LoadLevel ("Level 8");
	}
	public void level9(){
		MasterData.currentLevel = 9;
		Application.LoadLevel ("Level 9");
	}
	public void level10(){
		MasterData.currentLevel = 10;
		Application.LoadLevel ("Level 10");
	}
	public void level11(){
		MasterData.currentLevel = 11;
		Application.LoadLevel ("Level 11");
	}
	public void level12(){
		MasterData.currentLevel = 12;
		Application.LoadLevel ("Level 12");
	}
	public void level13(){
		MasterData.currentLevel = 13;
		Application.LoadLevel ("Level 13");
	}

}
