﻿using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	Transform muzzle;
	public Projectile projectile;
	public float msBetweenShots = 100;
	public float muzzleVelocity = 35;

	float nextShotTime;

	void Start() {
		muzzle = transform.FindChild ("Muzzle").transform;
	}

	public void Shoot () {
		if (Time.time > nextShotTime) {
			nextShotTime = Time.time + msBetweenShots / 1000;
			Projectile newProjectile = Instantiate (projectile, muzzle.position, muzzle.rotation) as Projectile;
			newProjectile.setSpeed (muzzleVelocity);
		}
	}

}
