using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LandMine : MonoBehaviour {

	[SerializeField]
	public GameObject explosion; 
	public GameObject mineObj;


	void OnTriggerEnter(Collider other) {
		Instantiate (explosion, mineObj.transform.position, mineObj.transform.rotation);
		var hit = other.gameObject;

		//Health and Scoring Code
		Debug.Log (other.name + " has been logged");
//		Player _player = GameManager.GetPlayer(other.name);
//		_player.TakeDamage (5);
		Destroy (mineObj);
	}

}
