using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
	public float speed  = 6.0f;
	public float jumpSpeed  = 8.0f;
	public float gravity  = 20.0f;
	// Use this for initialization
	private Vector3 moveDirection  = Vector3.zero;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			// We are grounded, so recalculate
			// move direction directly from axes
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,
			                        Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			
			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}
		
		// Apply gravity
		moveDirection.y -= gravity * Time.deltaTime;
		
		// Move the controller
		transform.Rotate (Vector3.up * Input.GetAxis ("Mouse X") * 2);
		controller.Move(moveDirection * Time.deltaTime);
	}
}

