using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redEyeTrigger : MonoBehaviour {


	public GameObject redEye;
	// Use this for initialization
	void Start () {
		redEye.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){

	
		if (col.gameObject.tag == "redEye") {
			
			redEye.SetActive(true);
		}
	
	}

	void OnTriggerExit(Collider col){


		if (col.gameObject.tag == "redEye") {

			redEye.SetActive(false);
		}

	}

	public void RedEyesOff(){
		redEye.SetActive(false);
	}
}
