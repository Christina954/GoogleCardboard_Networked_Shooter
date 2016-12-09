using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
	{
		
		var hit = coll.gameObject;
		hit = hit.transform.parent.gameObject;
		Debug.Log (hit + " " + hit);
		var health = hit.GetComponent<Player> ();
		if (health  != null)
		{
			Debug.Log ("Take Damage");
			health.TakeDamage(10);
		}
		Destroy(gameObject);
	}

}
