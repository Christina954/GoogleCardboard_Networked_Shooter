using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
	{
		
		var hit = coll.gameObject;
		var health = hit.GetComponent<Health> ();
		if (health  != null)
		{
			health.TakeDamage(10);
		}
		Destroy(gameObject);
	}

}
