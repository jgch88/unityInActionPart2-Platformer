using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
	public float smoothTime = 0.5f;
	private Vector3 _velocity = Vector3.zero;

	public Transform target;

	// LateUpdate executes every frame, but happens after Update()
	void LateUpdate () {
		// preserve z position, change x and y position
		Vector3 targetPosition = new Vector3 (
			target.position.x, target.position.y, transform.position.z);

		// Damp camera following, make it less jarring (because it would otherwise 
		// move exactly with the player). 
		transform.position = Vector3.SmoothDamp (transform.position,
			targetPosition, ref _velocity, smoothTime);
	}
}
