using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSoundScript : MonoBehaviour {

	public AudioSource Player;
	public AudioClip[] AttackSound;
	int random;
	// Use this for initialization

	public void Awake(){
		Player = GetComponent<AudioSource>();

	}

	void Update() 
	{

	}

	public void PlayAttackSound(){
		random=Random.Range(0,AttackSound.Length);
		Player.clip = AttackSound[random];
		Player.PlayOneShot(Player.clip);
	}

}
