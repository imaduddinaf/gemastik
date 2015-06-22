using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;

public class Backup : MonoBehaviour {
	private string data;
	public Text version;
	private float volume;
	private string gameVersion;
	private int levelMax;
	void LoadFromFile(){
		//json
		SimpleJSON.JSONNode node = SimpleJSON.JSONNode.Parse(File.ReadAllText(Application.dataPath +"/data.json"));
		gameVersion = node ["version"];
		volume = node ["volume"].AsFloat;
		levelMax = node ["levelmax"].AsInt;
		Debug.Log(gameVersion + "\n" + volume.ToString() + "\n" + levelMax.ToString());
		version.text = gameVersion;
	}
	void WriteToFile(){
		//json
		SimpleJSON.JSONNode node = SimpleJSON.JSONNode.Parse(File.ReadAllText(Application.dataPath +"/data.json"));
		node ["version"] = gameVersion;
		node["volume"].AsFloat = volume;
		node ["levelmax"].AsInt = levelMax;
		File.WriteAllText(Application.dataPath + "/data.json", node.ToString());
		//test
		/*if (System.IO.File.Exists("myfile.txt"))
		{
			//do stuff
		}*/
	}
	// Use this for initialization
	void Start () {
		if (System.IO.File.Exists ("data.json") == false) {
			string tmp = 
				"{\n" +
					"\t" + "\"version\" : \"v 1.0\" " + ", \n" + 
					"\t" + "\"volume\" : \"1.0\" " + ", \n" + 
					"\t" + "\"levelmax\" : \"2\" " + ", \n" + 
					"}";
			File.WriteAllText (Application.dataPath + "/data.json", tmp);
			LoadFromFile ();
		} else {
			LoadFromFile ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){
			volume += 0.1f;
			WriteToFile();
		}
	}
}
