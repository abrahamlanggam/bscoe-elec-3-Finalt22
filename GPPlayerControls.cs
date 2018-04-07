 using UnityEngine;
 using System.Collections;
 
 public class GPPlayerControls: MonoBehaviour {
 
	[SerializeField] Vector3 curLoc;
	[SerializeField] Vector3 prevLoc;
	[SerializeField] float timer=0;

//	public string upkey;
//	public string downkey;
//	public string leftkey;
//	public string rightkey;

	[SerializeField] float lookSpeed = 10;
	[SerializeField] int speed=2;
	[SerializeField] int points = 10;
    // public float sitTimer=.75f;
	private float horizontal;
	private float vertical;



	[SerializeField] Utilities.PlayerIdentity attachedPlayer;

	bool isAttacking = false;
	[SerializeField] float attackDuration = .7f;
	[SerializeField] int attackDamage = 5;

//	public bool playerone=true;
//	public bool playertwo=false;
//	public bool playerthree=false;
	public GameObject redeye;
	private Animator redFade;

	AttackSoundScript attackSound;
    ScoreManager scoreManager;
	GameOver gameOver;
    public Animator anim;

	public bool start;

	float collisionTimer=.6f;
	int index;

	void Start(){

		redFade=GameObject.Find("FlippedSphere").GetComponent<Animator>();

		start = false;
		collisionTimer = 0f;

        anim = GetComponent<Animator>();
		attackSound =gameObject.GetComponentInChildren<AttackSoundScript>();
		scoreManager =GameObject.FindObjectOfType<ScoreManager> ();
		gameOver = GameObject.FindObjectOfType<GameOver> ();

     }


	void FixedUpdate () 
	{  

		start = !gameOver.gameEnded;

		//attackClip= attack[index];

		if (!start)
			this.gameObject.SetActive (false);


		if (attachedPlayer == Utilities.PlayerIdentity.GPPlayer1) { 
			horizontal = Input.GetAxis ("P1_MoveHor"); 
			vertical = Input.GetAxis ("P1_MoveVer");
            Player1();
		} else if (attachedPlayer == Utilities.PlayerIdentity.GPPlayer2) {
			horizontal = Input.GetAxis ("P2_MoveHor"); 
			vertical = Input.GetAxis ("P2_MoveVer");
            Player2();
		} else if (attachedPlayer == Utilities.PlayerIdentity.GPPlayer3) {
			horizontal = Input.GetAxis ("P3_MoveHor"); 
			vertical = Input.GetAxis ("P3_MoveVer");
            Player3();
		}

		timer+=Time.deltaTime;
		InputListen();
		if (curLoc == prevLoc) {
			//Debug.Log("walking");
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isRun", false);


		} else {
			anim.SetBool("isRun",true);
			anim.SetBool("isIdle", false);

		}
	}




	void OnTriggerStay(Collider collidingObject)
	{		
		if (collidingObject.gameObject.tag == "HMD") {
			collisionTimer += Time.deltaTime;

			if (collisionTimer >= attackDuration) {
				AttackVRPlayer (collidingObject.gameObject);
				collisionTimer = 0f;

				StartCoroutine ("Pulse");
                redFade.SetBool("isAttack", true);
                SteamVR_Controller.Input(4).TriggerHapticPulse(1999);
				SteamVR_Controller.Input(3).TriggerHapticPulse(1999);

			}
		}
	}

	void OnTriggerEnter(Collider collidingObject){


		if (collidingObject.gameObject.tag == "HMD") {
			anim.SetBool ("isAttack", true);

            redFade.SetBool("isAttack", true);

        }
//		if (collidingObject.gameObject.tag == "bullet")
//		{
//			anim.SetBool("isDead",true);
//		}
	}

	void OnTriggerExit(Collider collidingObject)
	{
		if (collidingObject.gameObject.tag == "HMD") {
			isAttacking = false;
			collisionTimer = 0f;
			anim.SetBool("isAttack",false);

			redFade.SetBool ("isAttack", false);
		}
	}

	public void StartGame(bool i){
		start = i;
	}

	void AttackVRPlayer(GameObject playerGO)
	{
		attackSound.PlayAttackSound ();
		int damageDealt = playerGO.GetComponentInParent<VRPlayerHealth> ().TakeDamage (attackDamage);
		if (damageDealt > 0) {
			scoreManager.AddToScore (attachedPlayer, damageDealt);
			scoreManager.AddToScore (Utilities.PlayerIdentity.VRPlayer, -damageDealt);
		}
	}
     private void InputListen()
     {
         prevLoc = curLoc;
         curLoc = transform.position;

      
        if (start == true) {
			
			if (vertical==-1 ) {
                timer = 0;
                curLoc.z -= speed * Time.fixedDeltaTime;
                transform.position = curLoc;
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    Quaternion.LookRotation(transform.position - prevLoc), Time.fixedDeltaTime * lookSpeed);
                timer = 0;
            }
			if (horizontal== -1) {
				curLoc.x -= speed * Time.fixedDeltaTime;
				transform.position = curLoc;
				transform.rotation = Quaternion.Lerp (transform.rotation, 
					Quaternion.LookRotation (transform.position - prevLoc), Time.fixedDeltaTime * lookSpeed);
				timer = 0;
			}
			if (vertical ==1) {
                curLoc.z += speed * Time.fixedDeltaTime;
                transform.position = curLoc;
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    Quaternion.LookRotation(transform.position - prevLoc), Time.fixedDeltaTime * lookSpeed);
              
			}
			if (horizontal == 1) {
				curLoc.x += speed * Time.fixedDeltaTime;
				transform.position = curLoc;
				transform.rotation = Quaternion.Lerp (transform.rotation, 
					Quaternion.LookRotation (transform.position - prevLoc), Time.fixedDeltaTime * lookSpeed);
				timer = 0;
			}


           



        }
        

     }

    void Player1()
    {
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
        }else if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
        }
        else
        {
            vertical = 0;
        }


        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
        }
        else
        {
            horizontal = 0;
        }

    }

    void Player2()
    {
        if (Input.GetKey(KeyCode.T))
        {
            vertical = 1;
        }
        else if (Input.GetKey(KeyCode.G))
        {
            vertical = -1;
        }
        else
        {
            vertical = 0;
        }

        if (Input.GetKey(KeyCode.F))
        {
            horizontal = -1;
        }
        else if (Input.GetKey(KeyCode.H))
        {
            horizontal = 1;
        }
        else
        {
            horizontal = 0;
        }


    }
    void Player3()
    {
        if (Input.GetKey(KeyCode.I))
        {
            vertical = 1;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            vertical = -1;
        }
        else
        {
            vertical = 0;
        }


        if (Input.GetKey(KeyCode.J))
        {
            horizontal= -1;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            horizontal = 1;
        }
        else
        {
            horizontal = 0;
        }

    }

    public void Hit(){

	}

	IEnumerator Pulse(){
		
		yield return new WaitForSeconds(1f);
		//redFade.SetBool ("isAttack", false);

	}
 }