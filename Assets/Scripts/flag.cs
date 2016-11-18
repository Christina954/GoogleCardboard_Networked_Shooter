using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {
	public GameObject flagPrefab;

	void OnCollisionEnter(Collision collision)
	{
		var hit = collision.gameObject;

		if (flagPrefab.Equals (hit)) {
			var health = hit.GetComponent<playerHealth> ();
			if (health != null) {
				health.TakeDamage (10);
			}

			Destroy (gameObject);
		}
	}
}
