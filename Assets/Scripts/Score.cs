using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Score : NetworkBehaviour {
	public const int initScore = 0;
	public bool hasFlag;
	//private Time timeFlag;

	public GameObject flagprefab;

	[SyncVar(hook = "OnChangeScore")]
	public int currentScore = initScore;

	//public RectTransform healthBar;

	public void takeFlag()
	{
		if (!isServer)
			return;

		currentScore += 10;
		if (!hasFlag) {
			CmdFlag ();
			hasFlag = true;
		}

	}


	void OnChangeScore (int currentScore )
	{
		Debug.Log (currentScore);
	}

	[Command]
	void CmdFlag()
	{
		Vector3 tmp = this.gameObject.transform.position;
		tmp.x = 0.5f;
		tmp.z = 0.5f;

		var flag = (GameObject)Instantiate (flagprefab, tmp, this.gameObject.transform.rotation);

		NetworkServer.Spawn (flag);
	}


}
