using UnityEngine;
using System.Collections;

public class NaikTurunTaliDariKapal : MonoBehaviour {
	public GameObject camera;
	private int waktuNaik = 0;
	private int kedalaman = 0;
	private bool jalaDilempar = false;
	private bool lemparPertama = true;
	private float kecepatanAwal = 4f;
	private float kecepatanNaik = 0.5f;
	private float kecepatanTurun = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Debug.Log ("kena");
		}
		if(jalaDilempar){
			if (kedalaman < 50 && lemparPertama == true) {
				transform.Translate (Vector2.down * kecepatanAwal * Time.deltaTime);
				camera.transform.Translate (Vector2.down * kecepatanAwal * Time.deltaTime);
				kedalaman++;
			} else if(waktuNaik > 0){
				transform.Translate (Vector2.up * kecepatanNaik * Time.deltaTime);
				camera.transform.Translate (Vector2.up * kecepatanNaik * Time.deltaTime);
				waktuNaik--;
				kedalaman--;
			} else {
				lemparPertama = false;
				transform.Translate (Vector2.down * kecepatanTurun * Time.deltaTime);
				camera.transform.Translate (Vector2.down * kecepatanTurun * Time.deltaTime);
				kedalaman++;
			}
		}
	}

	public void NaikPakaiTombol(){
		waktuNaik = 30;
	}

	public void LemparJala(){
		jalaDilempar = true;
	}
}
