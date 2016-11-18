using UnityEngine;
using System.Collections;

public class flag : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
	{

		var hit = coll.gameObject;
		var health = hit.GetComponent<Health> ();
		if (health != false) {
			health.TakeDamage(-10);
		}
		Destroy(gameObject);
	}
}
