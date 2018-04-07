using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundScript : MonoBehaviour {

	public AudioSource Barrel;
	public AudioClip[] HitSound;
	int random;
	// Use this for initialization

	public void Awake(){
		Barrel = GetComponent<AudioSource>();
	}

	void Update() 
	{

	}

	public void PlayHitSound(){
		random=Random.Range(0,HitSound.Length);
		Barrel.clip = HitSound[random];
		Barrel.PlayOneShot(Barrel.clip);
	}

}
