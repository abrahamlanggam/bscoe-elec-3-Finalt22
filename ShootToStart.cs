using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHMD : MonoBehaviour {

	public GameObject playerHMD;
	public GameInitializer hmdStart;
	// Use this for initialization
	void Awake () {
		hmdStart = playerHMD.GetComponent<GameInitializer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "bullet") {
			hmdStart.SetVRPlayerReady(true);
			Destroy(gameObject);
		}

	}
}
