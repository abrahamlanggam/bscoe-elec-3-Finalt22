using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour {


	private Vector3 curLoc;
	private Vector3 prevLoc;
	public AudioClip audioclip;
	private AudioSource source;
	// Use this for initialization
	void Start () {


		source = gameObject.GetComponent <AudioSource>();
		source.clip = audioclip;
	}
	
	// Update is called once per frame
	void Update () {

		prevLoc = curLoc;
		curLoc = transform.position;
		transform.position = curLoc;
		if(curLoc==prevLoc){
			//Debug.Log("walking");

			source.Pause();

		} else {
			
			source.UnPause();
		}
	}
}
