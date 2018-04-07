using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {


	public float fireRate = 0.2f;	
	public ParticleSystem muzzleFlash;

	public ParticleSystem cartridgeEjection;
	public ParticleSystem bloodImpact;
	public ParticleSystem normalImpact;
	public ParticleSystem woodImpact;
	public ParticleSystem fire;

	public Transform spawn;
	public GameObject projectile;
	private SteamVR_TrackedController controller;
	private SteamVR_TrackedObject trackedObj;

	public AudioClip pew;
	public AudioClip deathSound;

	private AudioSource source;
	private float nextFire;		
	public bool CartridgeOn= false;
    private VRPlayerHealth vrHealth;
	private ScoreManager scoreManager;
	GameInitializer gameInitializer;


	float impactForce= 1000f;

	void Awake () {
        vrHealth= FindObjectOfType<VRPlayerHealth>();
		scoreManager = FindObjectOfType<ScoreManager> ();
		//controller = GetComponent<SteamVR_TrackedController>();
		//controller.TriggerClicked += Shoot;
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		source = GetComponent<AudioSource>();
		gameInitializer= GameObject.FindObjectOfType<GameInitializer> ();

	}

	private void FixedUpdate()
	{
		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)&& Time.time > nextFire)
		{
			device.TriggerHapticPulse(1999);
			RaycastGun ();
		}
	}

	void Shoot(object sender, ClickedEventArgs e)
	{



	}

	private void RaycastGun(){
		RaycastHit hit;
		if (Physics.Raycast (spawn.position, spawn.forward, out hit)) {
			//			

			if (hit.rigidbody != null) {

				hit.rigidbody.AddForce(-hit.normal*impactForce);
			}



			nextFire = Time.time + fireRate;
			source.PlayOneShot(pew, 1f);
			Debug.Log("shoot");
			//				GameObject newProjectile = Instantiate(projectile, spawn.position, transform.rotation) as GameObject;
			//				newProjectile.GetComponent<Rigidbody>().AddForce(spawn.forward * 100f, ForceMode.VelocityChange);

			muzzleFlash.Play ();

			if (CartridgeOn) {
				cartridgeEjection.Play();
			}


			if(hit.collider.gameObject.tag=="ShootToStart"){
				Destroy (hit.collider.gameObject);
				gameInitializer.SetVRPlayerReady(true);
			}

			if (hit.collider.gameObject.tag == "zombie") {
				Instantiate (bloodImpact, hit.point, Quaternion.LookRotation (hit.normal));
				Instantiate (fire, hit.transform.position, Quaternion.identity);
				source.PlayOneShot(deathSound);
				redEyeTrigger redEye;
				redEye = hit.collider.gameObject.GetComponent<redEyeTrigger> ();
//				redEye.RedEyesOff ();
			

				RandomSpawn randomSpawn;
				GPPlayerControls gpPlayers;
				randomSpawn = hit.collider.gameObject.GetComponent<RandomSpawn> ();
				randomSpawn.ZombieIsShot ();
                vrHealth.AddHP();
				scoreManager.AddToScore(Utilities.PlayerIdentity.VRPlayer, 5);

				gpPlayers=hit.collider.gameObject.GetComponent<GPPlayerControls> ();
				gpPlayers.Hit ();


			}if(hit.collider.gameObject.tag == "hittable"){
				
					HitSoundScript hitSound;
					hitSound = hit.collider.gameObject.GetComponent<HitSoundScript> ();
				if (hitSound != null) {
					hitSound.PlayHitSound ();
				}
				Instantiate (normalImpact, hit.point, Quaternion.LookRotation (hit.normal));
			}

		}
	}
}
