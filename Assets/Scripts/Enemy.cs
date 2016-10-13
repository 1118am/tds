using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {

	NavMeshAgent pathfiner;
	Transform target;

	void Start () {
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
			pathfiner.SetDestination (targetPostion);
			yield return new WaitForSeconds (refreshRate);
		}
	}

}
