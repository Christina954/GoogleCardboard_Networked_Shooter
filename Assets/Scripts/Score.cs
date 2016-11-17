using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Score : NetworkBehaviour {

	public const int initScore = 0;

	[SyncVar(hook = "OnChangeScore")]
	public int currentScore = initScore;

	public Text score;

	public bool hasFlag = false;

	public GameObject flagPrefab;
	public Vector3 flagSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (hasFlag) {
			
		}
	}

	void OnChangeScore (int currentScore)
	{
		score.text = "Score: " + currentScore;
	}

}
