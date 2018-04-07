using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewIndicator : MonoBehaviour {

	[SerializeField] Transform playerCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion lightRotation = Quaternion.Euler (0f, playerCamera.eulerAngles.y, 0f);
		transform.position = playerCamera.position;
		transform.rotation = lightRotation;
	}
}
