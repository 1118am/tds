using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PlayerController))]
[RequireComponent (typeof(GunController))]
public class Player : MonoBehaviour {


	float moveSpeed = 5;

	Camera viewCamera;
	PlayerController controller;
	GunController gunController;

	// Dev vars

	void Start () {
		viewCamera = Camera.main;
		controller = GetComponent<PlayerController> ();
		gunController = GetComponent<GunController> ();
	}
	
	void Update () {

		// Movement Input

		// Stores users input on the keyboard into the moveInput vector3
		// If player is going right moveInput will show (0, 0, 1)
		Vector3 moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		Vector3 moveVelocity = moveInput.normalized * moveSpeed;
		controller.Move(moveVelocity);


		// Look Input
		Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayDistance;

		if (groundPlane.Raycast (ray, out rayDistance)) {
			Vector3 point = ray.GetPoint (rayDistance);
			// Debug.DrawLine(ray.origin, point, Color.red);
			controller.LookAt(point);
		}


		// Weapon Input
		if (Input.GetMouseButton(0)) {
			gunController.Shoot ();
		}


	}
}
