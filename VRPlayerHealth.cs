using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRPlayerHealth : MonoBehaviour {

	[SerializeField] int playerHealth;
	[SerializeField] Slider healthBar;
	private GameOver gameOver;

	// Use this for initialization
	void Start () {
		
		playerHealth = 100;

		gameOver = GameObject.FindObjectOfType<GameOver> ();
		FindObjectOfType<ScoreManager> ().AddToScore (Utilities.PlayerIdentity.VRPlayer, playerHealth);
		//healthBar = GameObject.FindObjectOfType<Slider>().GetComponent<Slider> ();
		healthBar.value = playerHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int TakeDamage(int attackDamage)
	{
		
		int damageTaken = attackDamage;
		playerHealth -= attackDamage;
		UpdateHealthBar ();

		if (playerHealth <= 0) {
//			damageTaken = playerHealth + attackDamage;
			playerHealth = 0;
			KillPlayer ();
		}

		return damageTaken;
	}

	void UpdateHealthBar()
	{
		healthBar.value = playerHealth;
	}

	void KillPlayer()
	{
		gameOver.VRPlayerDead();
	}

    public void AddHP()
    {
        playerHealth += 5;
        healthBar.value = playerHealth;
    }
}
