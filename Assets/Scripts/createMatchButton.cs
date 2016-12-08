using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System.Collections;

public class createMatchButton : NetworkBehaviour , IGvrGazeResponder {

	// Use this for initialization
	void Start () {
		NetworkManager.singleton.StartMatchMaker();
	}

	// Update is called once per frame
	void Update () {

	}


	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
		Debug.Log ("On Gaze Enter");
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		Debug.Log ("On Gaze Exit");
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		Debug.Log ("On Gaze Trigger");
		NetworkManager.singleton.matchMaker.CreateMatch("match", 4, true, "", "", "", 0, 0, OnMatchCreate);
	}

	#endregion

	public void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
	{
		if (success)
		{
			//Debug.Log("Create match succeeded");

			MatchInfo hostInfo = matchInfo;
			NetworkServer.Listen(hostInfo, 9000);

			NetworkManager.singleton.StartHost(hostInfo);
		}
		else
		{
			Debug.LogError("Create match failed");
		}
	}
}

