using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour {

	public AudioSource Player;
	public AudioClip RustlingNoise;
	[SerializeField] Vector3 curLoc;
	[SerializeField] Vector3 prevLoc;
	// Use this for initialization

	public void Awake(){
		Player = GetComponent<AudioSource>();
		Player.clip = RustlingNoise;
		Player.Play();
	}

	void FixedUpdate() 
	{
		
		prevLoc = curLoc;
		curLoc = transform.position;

		if (curLoc == prevLoc) {
			
			Player.Pause();


		} else {

			Player.UnPause();
			
	
	
		}
	}
}
