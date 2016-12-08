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

	private NetworkStartPosition[] spawnPoints;

	void Start ()
	{
		if (isLocalPlayer)
		{
			spawnPoints = FindObjectsOfType<NetworkStartPosition>();
			Debug.Log ("hello");
			//Att 1: Turn off camera nonlocal
			//needs to run before anything else in awake
			var cam = this.transform.Find ("Player/Visor/Camera");
			//Robot Kyle: var cam = this.transform.Find ("Root/Ribs/Neck/Head/Visor/Camera");
			Debug.Log (cam.name);
			Debug.Log (cam.gameObject.activeInHierarchy);
			cam.gameObject.SetActive (true);
			Debug.Log (cam.gameObject.activeInHierarchy);

		}
	}

	public void SetDefaults(){
		currentHealth = maxHealth;
	}

	public void TakeDamage(int amount){
		if (!isServer)
			return;
		
		currentHealth -= amount;
		Debug.Log (transform.name + " now has " + currentHealth + " health.");

	}

	[ClientRpc]
	void RpcRespawn()
	{
		if (isLocalPlayer)
		{
			// Set the spawn point to origin as a default value
			Vector3 spawnPoint = Vector3.zero;

			// If there is a spawn point array and the array is not empty, pick one at random
			if (spawnPoints != null && spawnPoints.Length > 0)
			{
				spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
			}

			// Set the player’s position to the chosen spawn point
			transform.position = spawnPoint;
		}
	}
}
