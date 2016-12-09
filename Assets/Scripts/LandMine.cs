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
		hit = hit.transform.parent.gameObject;
		Debug.Log (hit + " " + hit);
		var health = hit.GetComponent<Player> ();
		if (health  != null)
		{
			Debug.Log ("Take Damage");
			health.TakeDamage(15);
		}
		Destroy(gameObject);

		Destroy (mineObj);
	}

}
