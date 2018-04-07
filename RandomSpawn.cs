using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {


    public Transform[] spawn;
    int random;
	// Use this for initialization
	public ParticleSystem fire;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ZombieIsShot(){
		gameObject.SetActive(false);
		Invoke("Delay", 2);
	}
//    private void OnCollisionEnter(Collision col)
//    {
//       
//        if (col.gameObject.tag == "bullet")
//        {
//         
//        }
//    }

    public void Delay(){
        gameObject.SetActive(true);
        random=Random.Range(0,12);

		Instantiate (fire, spawn[random].position, Quaternion.identity);
        gameObject.transform.position= spawn[random].position;

    }
}
