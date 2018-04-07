using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_VRPlayer : MonoBehaviour {

	[SerializeField] Transform playerTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (playerTransform.position.x, 0.1f, playerTransform.position.z);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, playerTransform.eulerAngles.y, transform.eulerAngles.z);
	}
}
