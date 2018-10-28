using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public Vector3 finishPos = Vector3.zero;
	public float speed = 0.5f;

	private Vector3 _startPos;
	private float _trackPercent = 0; // How far along "track" between start and finish
	private int _direction = 1;

	void Start () {
		_startPos = transform.position;
	}
	
	void Update () {
		_trackPercent += _direction * speed * Time.deltaTime;
		float x = (finishPos.x - _startPos.x) * _trackPercent + _startPos.x;
		float y = (finishPos.y - _startPos.y) * _trackPercent + _startPos.y;
		transform.position = new Vector3 (x, y, _startPos.z);

		if ((_direction == 1 && _trackPercent > 0.9f) ||
		    (_direction == -1 && _trackPercent < 0.1f)) {
			_direction *= -1;
		}
	}

	// Script that affects Unity's editor, but not the game!
	// Sort of like a visual scene helper. This script
	// draws a red line to indicate the moving platform's path
	// from start to end positions.
	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, finishPos);
	}
}
