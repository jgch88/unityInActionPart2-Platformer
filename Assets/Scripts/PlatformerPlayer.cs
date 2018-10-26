﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour {
	public float speed = 250.0f;

	private Rigidbody2D _body;

	void Start () {
		_body = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		Vector2 movement = new Vector2 (deltaX, _body.velocity.y);
		_body.velocity = movement;
	}
}
