using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	public Gun startingGun;

	Transform weaponHold;
	Gun equippedGun;

	void Start () {
		weaponHold = transform.FindChild ("Weapon Hold").transform;
		if (startingGun != null) {
			EquipGun (startingGun);
		}
	}

	public void EquipGun(Gun gunToEquip) {
		if (equippedGun != null) {
			Destroy (equippedGun.gameObject);
		}
		equippedGun = Instantiate (gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
		equippedGun.transform.parent = weaponHold;
		
	}

	public void Shoot () {
		if (equippedGun != null) {
			equippedGun.Shoot ();
		}
	}

}
