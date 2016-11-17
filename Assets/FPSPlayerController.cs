using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class FPSPlayerController : MonoBehaviour {

	[SerializeField]
	public float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 3f;


	private PlayerMotor motor;

	void Start ()
	{
		motor = GetComponent<PlayerMotor>();
	}

	void Update() {
		//calculate movement velocity

		float xMov = Input.GetAxisRaw ("Horizontal");
		float zMov = Input.GetAxisRaw ("Vertical");

		Vector3 moveHorizontal = transform.right * xMov;
		Vector3 moveVertical = transform.forward * zMov;

		// final movement vector
		Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

		//Apply movement
		motor.Move (velocity);

		//calculate rotation as a 3D vector
		float _yRot = Input.GetAxisRaw("Mouse X");
		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;

		//Apply Rotation
		motor.Rotate(_rotation);

		//Apply rotation
		motor.Rotate(_rotation);

		//Calculate camera rotation as a 3D vector (turning around)
		float _xRot = Input.GetAxisRaw("Mouse Y");

		float _cameraRotationX = _xRot * lookSensitivity;

		//Apply camera rotation
		motor.RotateCamera(_cameraRotationX);



	}



}
