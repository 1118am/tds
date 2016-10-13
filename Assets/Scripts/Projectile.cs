using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	float speed = 10;

	public void setSpeed (float newSpeed) {
		speed = newSpeed;
	}

	void Start () {
	
	}
	
	void Update () {
	
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}
}
