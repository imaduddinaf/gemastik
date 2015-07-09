using UnityEngine;
using System.Collections;

public class RotatePenggulungTali : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RotateLeft();
	}

	public void RotateRight(){
		transform.Rotate(0, 0, -30, Space.World);
	}

	public void RotateLeft(){
		transform.Rotate(0, 0, 40.0f * Time.deltaTime, Space.World);
	}
}
