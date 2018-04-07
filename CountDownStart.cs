using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownStart : MonoBehaviour {


	public string[] cd;
    Text num;
	// Use this for initialization


	public void Start(){
        num = gameObject.GetComponent<Text>();
		StartCoroutine ("startCD");
	}
	 IEnumerator startCD()
	{
        //destroy all game objects

        num.text = cd[0];
		yield return new WaitForSeconds(1f);
        num.text = cd[1];
        yield return new WaitForSeconds(1f);
        num.text = cd[2];
        yield return new WaitForSeconds(1f);
        num.text = cd[3];
        yield return new WaitForSeconds(1f);
        
        
        gameObject.SetActive(false);
    }
}
