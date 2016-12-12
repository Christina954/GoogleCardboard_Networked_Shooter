using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : NetworkBehaviour {

	[SerializeField]
	public const int maxHealth = 100;

	[SyncVar(hook = "OnChangeHealth")]
	public int currentHealth = maxHealth;

	public GameObject bulletPrefab;

	public Transform bulletSpawn;

	public RectTransform healthBar;


	void Awake(){
		SetDefaults ();
	}

	private NetworkStartPosition[] spawnPoints;

	void Start ()
	{
//		EventTrigger trigger = GetComponentInParent<EventTrigger>();
//		EventTrigger.Entry entry = new EventTrigger.Entry();
//		entry.eventID = EventTriggerType.PointerClick;
//		entry.callback.AddListener( (eventData) => { itWorked(); } );
//		trigger.delegates.Add(entry);
	}

	void Update()
	{

			
		if (!isLocalPlayer) {
			return;
		}

			spawnPoints = FindObjectsOfType<NetworkStartPosition>();
			//Att 1: Turn off camera nonlocal
			//needs to run before anything else in awake
			var cam = this.transform.Find ("Player/Visor/Camera");
			cam.gameObject.SetActive (true);

			this.GetComponentInChildren<GvrHead> ().enabled = true; 

		

		if (GvrViewer.Instance.Triggered) {
			CmdFire();
			Debug.Log ("IT WORKED");
		}
	}

	[Command]
	void CmdFire()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate (
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = this.transform.GetChild(0).forward * 6;

		NetworkServer.Spawn(bullet);

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}

	public void SetDefaults(){
		currentHealth = maxHealth;
	}

	public void TakeDamage(int amount){
		if (!isServer)
			return;
		
		currentHealth -= amount;
		Debug.Log (transform.name + " now has " + currentHealth + " health.");

		Debug.Log ("Current Health: " + currentHealth);
		if (currentHealth <= 0)
		{
			currentHealth = maxHealth;

			// called on the Server, invoked on the Clients
			RpcRespawn();

		}


	}

	void OnChangeHealth (int currentHealth )
	{
		Debug.Log("Health = " + currentHealth);
		Debug.Log(healthBar);
		Debug.Log(healthBar.sizeDelta);
		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);

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
