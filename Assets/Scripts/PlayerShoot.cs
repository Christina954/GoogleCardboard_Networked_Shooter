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
			if (_hit.collider.tag == PLAYER_TAG) {
				CmdPlayerShot (_hit.collider.name);
			}
		}
	}

	[Command]
	void CmdPlayerShot(string _ID){
		Debug.Log (_ID + " has been shot");
	}
}
