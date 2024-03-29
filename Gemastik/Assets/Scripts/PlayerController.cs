﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector2 movement = new Vector2 (moveHorizontal, 0.0f);

		rb.AddForce (movement*speed);
	}
}
