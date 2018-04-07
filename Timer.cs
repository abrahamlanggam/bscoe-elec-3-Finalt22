using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


    public float gameTime;
    private float time;
    public bool start;
    public Text timer;
	public Text timer3D;
    private float minutes;
    private float seconds;
    public int mult=1;
	private GameOver gameOver;

    	// Use this for initialization
	void Start () {
		float gameTime = 180;
		float time = 0;
		bool start = false;
		float minutes= 0;
		float seconds=0;

		gameOver = GameObject.FindObjectOfType<GameOver> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(start==true&&gameOver.gameEnded==false){
            gameTime-=Time.deltaTime*mult;
        }

        if(gameTime <= 0){ 
			
            start=false;
            gameTime=180;
			gameOver.Restart ();

        }

        minutes = Mathf.Floor(gameTime / 60); 
        seconds = Mathf.RoundToInt(gameTime%60);


        timer.text= minutes.ToString("0") + ":" + seconds.ToString("00");
		timer3D.text= minutes.ToString("0") + ":" + seconds.ToString("00");


	}

	public void StartGame (){
		start = true;
	}


}
