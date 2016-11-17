//using UnityEngine;
//
//[RequireComponent(typeof(PlayerMotor))]
//public class FPSPlayerController : MonoBehaviour {
//
//	public float speed = 5f;
//
//	private PlayerMotor motor = GetComponent<PlayerMotor>();
//
//	void Update() {
//		//calculate movement velocity
//
//		float xMov = Input.GetAxisRaw ("Horizontal");
//		float zMov = Input.GetAxisRaw ("Vertical");
//
//		Vector3 moveHorizontal = transform.right * xMov;
//		Vector3 moveVertical = transform.forward * zMov;
//
//		// final movement vector
//		Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;
//
//		motor.Move (velocity);
//	}
//
//
//
//}
