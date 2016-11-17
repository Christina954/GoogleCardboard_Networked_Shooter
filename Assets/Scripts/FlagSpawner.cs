using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class FlagSpawner : NetworkBehaviour {
	public GameObject flagPrefab;

	public override void OnStartServer(){
		var flag = (GameObject)Instantiate(flagPrefab, new Vector3(0.0f, 0.0f,0.0f), Quaternion.Euler( -90.0f, 45.0f, 180.0f));
		NetworkServer.Spawn(flag);
	}

}
