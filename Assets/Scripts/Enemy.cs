﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]
public class Enemy : LivingEntity {

	NavMeshAgent pathfiner;
	Transform target;

	protected override void Start () {
		base.Start ();
		pathfiner = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		StartCoroutine (UpdatePath());
	}
	
	void Update () {
		
	}

	IEnumerator UpdatePath () {
		float refreshRate = 0.25f;
		while (target != null) {
			Vector3 targetPostion = new Vector3 (target.position.x, 0, target.position.z);
			if (!dead) {
				pathfiner.SetDestination (targetPostion);
			}
			yield return new WaitForSeconds (refreshRate);
		}
	}

}
