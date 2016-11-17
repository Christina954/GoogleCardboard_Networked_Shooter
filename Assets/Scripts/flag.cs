using UnityEngine;
using System.Collections;

public class flag : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
	{
		var hit = coll.gameObject;
		var score = hit.GetComponent<Score> ();
		if (score.hasFlag  == false)
		{
			Debug.Log ("Collision");
			Destroy(gameObject);
		}

	}
}
