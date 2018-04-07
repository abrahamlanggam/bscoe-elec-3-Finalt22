using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {


	[SerializeField] GameObject Win;
	[SerializeField] GameObject Failed;
	[SerializeField] GameObject Survived;
	[SerializeField] GameObject Dead;

	[SerializeField] bool HMDWin;


	[SerializeField] Text p1score;
	[SerializeField] Text p2score;
	[SerializeField] Text p3score;

	int player1Score;
	int player2Score;
	int player3Score;

	Animator start1;
	Animator start2;
	Animator start3;
	Animator starthmd;

	[SerializeField] GameObject EndIcon;
	Animator EndAnim;

	float delay=0;
	public bool gameEnded;


	void Start(){
		player1Score=0;
		player2Score=0;
		player3Score=0;
		HMDWin = true;
		gameEnded = false;
	}
	// Use this for initialization
	void Awake () {
		EndAnim= EndIcon.GetComponent<Animator>();

	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.R))  {			
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		if(gameEnded)
		RestartOnClick ();
	}

	public void Restart(){
		gameEnded = true;
		DisableScripts ();

		if (HMDWin) {
			Failed.SetActive (true);
			Survived.SetActive (true);
			delay = 8f;

		} else {
			Win.SetActive (true);
			Dead.SetActive (true);
			delay = 2f;
			StartCoroutine ("PlayerScore");
			StartCoroutine ("RemoveIconText");

		}

//		StartCoroutine ("DelayRestart");

	}

	public void ReceiveScore(int one, int two, int three){
		player1Score = one;
		player2Score = two;
		player3Score = three;
	}


	 IEnumerator PlayerScore(){
		yield return new WaitForSeconds(2f);


		EndAnim.SetBool ("end", true);
		p1score.text=player1Score.ToString();
		p2score.text=player2Score.ToString();
		p3score.text=player3Score.ToString();

		if (player1Score >= player2Score && player1Score >= player3Score) {
			EndAnim.SetBool ("p1", true);
		}

		if (player2Score >= player1Score && player2Score >=player3Score) {

			EndAnim.SetBool ("p2", true);
		}
		if (player3Score>= player2Score && player3Score >= player1Score) {

			EndAnim.SetBool ("p3", true);
		}

	}



	public void RestartOnClick(){
		

		
		if (Input.GetKey(KeyCode.Joystick1Button9)|| Input.GetKey(KeyCode.Joystick2Button9)|| Input.GetKey(KeyCode.Joystick3Button9)) {			
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	}

//	 IEnumerator DelayRestart(){
//		yield return new WaitForSeconds(8f);
//
//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//
//	
//	}

	IEnumerator RemoveIconText(){
		yield return new WaitForSeconds(delay);

		Win.SetActive (false);


		Failed.SetActive (false);
		Survived.SetActive (false);
	}

	public void VRPlayerDead(){
		HMDWin = false;
		Restart ();
	}

	public void DisableScripts(){
		
	}
}
