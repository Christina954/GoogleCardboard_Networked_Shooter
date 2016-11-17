using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class FlagSpawner : NetworkBehaviour {
	public GameObject flagPrefab;
	public Vector3 spawnPosition;

	public override void OnStartServer(){
		var flag = (GameObject)Instantiate(flagPrefab, spawnPosition, Quaternion.Euler( -90.0f, 45.0f, 180.0f));
		NetworkServer.Spawn(flag);
	}

}
