using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class startMatchMaker : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		NetworkManager.singleton.StartMatchMaker();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
