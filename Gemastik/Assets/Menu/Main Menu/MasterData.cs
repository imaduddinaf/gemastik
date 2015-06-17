using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;

public class MasterData : MonoBehaviour {
	private string data;
	public Text version;
	public static int currentLevel = 0;
	public static float volume;
	public static string gameVersion;
	public static int levelMax;
	void LoadFromFile(){
		//player perf
		volume = PlayerPrefs.GetFloat ("Volume");
		levelMax = PlayerPrefs.GetInt ("Level Max");
		gameVersion = PlayerPrefs.GetString ("Version");
	}
	public static void WriteToFile(){
		//player perf
		PlayerPrefs.SetFloat ("Volume", 1.0f);
		PlayerPrefs.SetInt ("Level Max", levelMax);
		PlayerPrefs.SetString ("Version", "0.1");
	}
	private void SetPlayerPrefs() {
		//simpan punya perf
		PlayerPrefs.SetInt ("Perf", 1);
		//simpan volume
		if (PlayerPrefs.HasKey ("Volume") == false) {
			PlayerPrefs.SetFloat ("Volume", 1.0f);
		}
		//simpan gameversion
		if (PlayerPrefs.HasKey ("Version") == false) {
			PlayerPrefs.SetString ("Version", "0.1");
		}
		//simpan level max
		if (PlayerPrefs.HasKey ("Level Max") == false) {
			PlayerPrefs.SetInt ("Level Max", 1);
		}
		//simpan skor level
		for (int i = 1; i <= levelMax; i++) {
			if(PlayerPrefs.HasKey ("Level " + i) == false){
				PlayerPrefs.SetFloat ("Level " + i, 0.0f);
			}
		}
	}
	public static float ChangeHighScore(string lvl, float scr){
		//jika lebih besar, set
		if (PlayerPrefs.GetFloat (lvl) < scr) { 
			PlayerPrefs.SetFloat (lvl, scr);
			return scr;
		} 
		return PlayerPrefs.GetFloat (lvl);
		//jika tidak, abaikan
	}

	// Use this for initialization
	void Start () {
		//awal instal
		if (PlayerPrefs.HasKey ("Perf") == false) {
			//set gameversion
			//set volume
			//set max level yang sudah dicapai
			//set skor tiap level
			Debug.Log("asd");
			SetPlayerPrefs ();
		} 
		LoadFromFile();

		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (levelMax);
		Debug.Log (volume);
		version.text = gameVersion;
		AudioListener.volume = volume;
		if (currentLevel > levelMax) {
			levelMax = currentLevel;
			WriteToFile ();
		}
		//Debug.Log (MasterData.GameVersion);
	}

	//setter getter
	public static string GameVersion
	{
		get { return gameVersion; }
		set { gameVersion = value; }
	}
}
