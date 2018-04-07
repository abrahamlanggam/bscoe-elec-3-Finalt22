using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {


//    public int s1=0;
//  	 public int s2=0;
//    public int s3=0;
//	public int hmd = 0;
//
//    public Text score1;
//    public Text score2;
//    public Text score3;
//	public Text scorehmd;

	int[] playerScores = new int[4];
	[SerializeField] Text[] playerScoreText;

	private GameOver gameOver;

	// Use this for initialization
	void Start () {
		gameOver = GameObject.FindObjectOfType<GameOver> ();
	}
	
	// Update is called once per frame
	void Update () {
    }

	public void AddToScore(Utilities.PlayerIdentity playerIdentity, int scoreToAdd)
	{
//		Debug.Log ((int)playerIdentity);
		playerScores [(int) playerIdentity] += scoreToAdd;
		UpdateScoreText ();
	}

	void UpdateScoreText()
	{
		for (int i = 0; i <= 3; i++) {
			playerScoreText [i].text = playerScores [i].ToString ();
		}

		gameOver.ReceiveScore (playerScores[1], playerScores[2], playerScores[3]);
	}


}
