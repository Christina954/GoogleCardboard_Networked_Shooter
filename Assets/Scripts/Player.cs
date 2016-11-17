using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

	[SerializeField]
	private int maxHealth = 100;

	[SyncVar]
	private int currentHealth;

	void Awake(){
		SetDefaults ();
	}

	public void SetDefaults(){
		currentHealth = maxHealth;
	}

	public void TakeDamage(int amount){
		currentHealth -= amount;
		Debug.Log (transform.name + " now has " + currentHealth + " health.");

	}
}
