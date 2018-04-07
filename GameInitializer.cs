using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInitializer : MonoBehaviour {
    public GameObject Intro;
	public bool isGPPlayer1Ready;
	public bool isGPPlayer2Ready;
	public bool isGPPlayer3Ready;
	public bool isVRPlayerReady;

    [SerializeField] GameObject title;

    [SerializeField]  GameObject gpPlayer1Prefab;
	[SerializeField]  GameObject gpPlayer2Prefab;
	[SerializeField]  GameObject gpPlayer3Prefab;
	[SerializeField]  GameObject vrPlayerPrefab;

	//script of players
	GPPlayerControls gpPlayer1Controls;
	GPPlayerControls gpPlayer2Controls;
	GPPlayerControls gpPlayer3Controls;

	//gameobject of each player start
	[SerializeField]  GameObject gpPlayer1StartIcon;
	[SerializeField]  GameObject gpPlayer2StartIcon;
	[SerializeField]  GameObject gpPlayer3StartIcon;
	[SerializeField]  GameObject vrPlayerStartIcon;
	[SerializeField]  GameObject startText;


	[SerializeField]  GameObject gpPlayer1StartIcon3D;
	[SerializeField]  GameObject gpPlayer2StartIcon3D;
	[SerializeField]  GameObject gpPlayer3StartIcon3D;
	[SerializeField]  GameObject vrPlayerStartIcon3D;

	//start buttons animation
	private Animator gpPlayer1StartAnim;
	private Animator gpPlayer2StartAnim;
	private Animator gpPlayer3StartAnim;
	private Animator vrPlayerStartAnim;

	//start buttons animation
	private Animator gpPlayer1StartAnim3D;
	private Animator gpPlayer2StartAnim3D;
	private Animator gpPlayer3StartAnim3D;
	private Animator vrPlayerStartAnim3D;

	private bool isGameRunning;

	[SerializeField]  Timer timer;
	[SerializeField]  GameObject CD1233D;
	[SerializeField]  GameObject CD1232D;


	[SerializeField]  Transform[] gpPlayerSpawnPoints;
	int random;

	public ParticleSystem fire;

    // Use this for initialization

    





    void Start () {
		bool isGPPlayer1Ready= false;
		bool isGPPlayer2Ready= false;
		bool isGPPlayer3Ready= false;
		bool isVRPlayerReady= false;
		isGameRunning = false;
	}

	void Awake(){

        DontDestroyOnLoad(Intro);
        gpPlayer1StartAnim = gpPlayer1StartIcon.GetComponent<Animator>();
		gpPlayer2StartAnim = gpPlayer2StartIcon.GetComponent<Animator>();
		gpPlayer3StartAnim = gpPlayer3StartIcon.GetComponent<Animator>();
		vrPlayerStartAnim = vrPlayerStartIcon.GetComponent<Animator>();

		gpPlayer1StartAnim3D = gpPlayer1StartIcon3D.GetComponent<Animator>();
		gpPlayer2StartAnim3D = gpPlayer2StartIcon3D.GetComponent<Animator>();
		gpPlayer3StartAnim3D = gpPlayer3StartIcon3D.GetComponent<Animator>();
		vrPlayerStartAnim3D = vrPlayerStartIcon3D.GetComponent<Animator>();

		gpPlayer1Controls = gpPlayer1Prefab.GetComponent<GPPlayerControls> ();
		gpPlayer2Controls = gpPlayer1Prefab.GetComponent<GPPlayerControls> ();
		gpPlayer3Controls = gpPlayer1Prefab.GetComponent<GPPlayerControls> ();
	}

	// Update is called once per frame
	void Update () {




		if (!isGameRunning) {
			CheckPlayersIfReady ();

			if (isGPPlayer1Ready == true) {
				gpPlayer1StartAnim.SetBool ("s1", isGPPlayer1Ready);
				gpPlayer1StartAnim3D.SetBool ("s1", isGPPlayer1Ready);
			}
			if (isGPPlayer2Ready == true) {
				gpPlayer2StartAnim.SetBool ("s2", isGPPlayer2Ready);
				gpPlayer2StartAnim3D.SetBool ("s2", isGPPlayer2Ready);
			}
			if (isGPPlayer3Ready == true) {
				gpPlayer3StartAnim.SetBool ("s3", isGPPlayer3Ready);
				gpPlayer3StartAnim3D.SetBool ("s3", isGPPlayer3Ready);
			}
			if (isVRPlayerReady == true) {
				vrPlayerStartAnim.SetBool ("hmd", isVRPlayerReady);
				vrPlayerStartAnim3D.SetBool ("hmd", isVRPlayerReady);

			}
		}

		if(isGPPlayer1Ready == true && isGPPlayer2Ready == true && isGPPlayer3Ready == true && isVRPlayerReady == true ){
			//check if all player are ready
			StartGame ();
		}

		//buttons for start while game not starting else player movement buttons is activated


	}

	public void StartGame(){
		isGameRunning = true;

		StartCoroutine ("RemoveStartIcons");
		StartCoroutine ("StartOfGame");


		//remove start buttons

		//display countdown on both 3d and 2d view

		isGPPlayer1Ready = false;
		isGPPlayer2Ready = false;
		isGPPlayer3Ready = false;
		isVRPlayerReady = false;;

       
		//only once true //always false when not needed
	}

	IEnumerator StartOfGame(){
		yield return new WaitForSeconds(4f);

		timer.StartGame();
		//start timer

		gpPlayer1Controls.StartGame(isGameRunning);
		gpPlayer2Controls.StartGame(isGameRunning);
		gpPlayer3Controls.StartGame(isGameRunning);
		SpawnGPPlayers ();
		//start movement script for players
	}

	IEnumerator RemoveStartIcons(){
		yield return new WaitForSeconds(.6f);
		CD1233D.SetActive(true);
		CD1232D.SetActive(true);
		startText.SetActive (false);
		gpPlayer1StartIcon.SetActive (false);
		gpPlayer2StartIcon.SetActive (false);
		gpPlayer3StartIcon.SetActive (false);
		vrPlayerStartIcon.SetActive (false);
		gpPlayer1StartIcon3D.SetActive (false);
		gpPlayer2StartIcon3D.SetActive (false);
		gpPlayer3StartIcon3D.SetActive (false);
		vrPlayerStartIcon3D.SetActive (false);
        title.SetActive(false);

	}

	void CheckPlayersIfReady(){

		//float p1Start=Input.GetAxis("P1_Start");
		//float p2Start=Input.GetAxis("P2_Start");
		//float p3Start=Input.GetAxis("P3_Start");

		if (Input.GetKey (KeyCode.Z) || Input.GetKey(KeyCode.Joystick1Button9))  {			
			isGPPlayer1Ready = true;
            Debug.Log("Player 1 start!");
           
        }
		if (Input.GetKey (KeyCode.X) || Input.GetKey(KeyCode.Joystick2Button9)) {			
			isGPPlayer2Ready = true;
            Debug.Log("Player 2 start!");
        }
		if (Input.GetKey (KeyCode.C) || Input.GetKey(KeyCode.Joystick3Button9)) {
			isGPPlayer3Ready = true;
            Debug.Log("Player 3 start!");
        }
		if (Input.GetKey (KeyCode.V)) {
			isVRPlayerReady = true;
            Debug.Log("Player VR start!");
        }
	}

	public void SpawnGPPlayers(){
		random=Random.Range(0,12);

		Instantiate (fire, gpPlayerSpawnPoints [random].position, Quaternion.identity);
		Instantiate (gpPlayer1Prefab, gpPlayerSpawnPoints [random].position, gpPlayerSpawnPoints [random].rotation);
		random=Random.Range(0,12);
		Instantiate (fire, gpPlayerSpawnPoints [random].position, Quaternion.identity);
		Instantiate (gpPlayer2Prefab, gpPlayerSpawnPoints [random].position, gpPlayerSpawnPoints [random].rotation);
		random=Random.Range(0,12);
		Instantiate (fire, gpPlayerSpawnPoints [random].position, Quaternion.identity);
		Instantiate (gpPlayer3Prefab, gpPlayerSpawnPoints [random].position, gpPlayerSpawnPoints [random].rotation);
	}

	public void SetVRPlayerReady(bool isReady){
		isVRPlayerReady = isReady;
	}
}
