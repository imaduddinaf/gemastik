using UnityEngine;
using System.Collections;

public class GCollector : MonoBehaviour {
	public static bool created = false;
	void Awake () {
		if (!created) {
			DontDestroyOnLoad (transform.gameObject);
			created = true;
		} else {
			Destroy(transform.gameObject);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount % 30 == 0)
		{
			System.GC.Collect();
		}
	}
}
