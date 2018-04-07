using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int points = 10;
  
    public ScoreManager score;
	// Use this for initialization
	void Start () {
        Invoke("selfDestruct", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision col)
    {
		
			selfDestruct();
		
        
    }
    void selfDestruct()
    {
        Destroy(gameObject);
    }
}
