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
		var health = hit.GetComponent<Health> ();
		if (health  != null)
		{
			health.TakeDamage(5);
		}
		Destroy (mineObj);
	}

}
