using UnityEngine;
using System.Collections;

public class flag : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
	{

		GameObject hit = coll.gameObject;
		hit = hit.transform.parent.gameObject;
		Debug.Log (hit + " " + hit);
		var health = hit.GetComponent<Player> ();
		if (health != false) {
			Debug.Log ("Take Damage");
			health.TakeDamage(10);
		}
		//Destroy(gameObject);
	}
}
