﻿using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

	private const string PLAYER_TAG = "Player";

	[SerializeField]
	private Camera cam;

	public PlayerWeapon weapon;

	[SerializeField]
	private LayerMask mask;

	void Start() {
		if (cam == null) {
			Debug.Log ("No camera referenced");
			this.enabled = false;
		}
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Shoot ();
			Debug.Log ("that was a shot!!");
		}
	}

	[Client]
	void Shoot(){
		RaycastHit _hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask)) {
			Debug.Log ("We hit: " + _hit.collider.name);
			Debug.Log ("this is the " + _hit.collider.tag + " and this is the " + PLAYER_TAG);
			Debug.Log (_hit.collider.tag == PLAYER_TAG);
			Debug.Log (string.Equals(_hit.collider.tag, PLAYER_TAG));
			if (string.Equals(_hit.collider.tag, PLAYER_TAG)) {
				Debug.Log ("i am on the iniside");
				CmdPlayerShot (_hit.collider.name, weapon.damage);
			}
		}
	}

	[Command]
	void CmdPlayerShot(string _playerID, int _damage){
		Debug.Log (_playerID + " has been shot");

		Player _player = GameManager.GetPlayer (_playerID);
		_player.TakeDamage (_damage);
	}
}