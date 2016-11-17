using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;



public class TeamNetworkManager : NetworkManager {
	bool multOfTwo;
	bool multOfThree;
	List<int> team1;
	List<int> team2;
	List<int> team3;

	public override void OnServerConnect (NetworkConnection conn){
		// if 0 add to 1 and wait until 2 -> continue

		//if 1 add to team 2 and continue

		//Things like 2 -> 3 or 8 -> 9  * Notable not 4 -> 5
		//if the list is divisible 2 and with new person it divides by 3
		//add new to team 3
		//add connection to the third team
		//take difference from (i/2) and ((i+1)/3) from team 1 and 2 

		base.OnServerConnect(conn);


	}

	// called when a client disconnects
	public override void OnServerDisconnect(NetworkConnection conn)
	{
		base.OnServerDisconnect(conn);
	}

	// called when a client is ready
	public override void OnServerReady(NetworkConnection conn)
	{
		base.OnServerReady (conn);
	}

	// called when a new player is added for a client
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		base.OnServerAddPlayer (conn, playerControllerId);
	}



}
