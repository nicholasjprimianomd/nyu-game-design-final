using UnityEngine;
using System.Collections;

public class AddPlayerAmmo : MonoBehaviour
{

	public Transform playerLocation;
	public PlayerShoot playerAmmo;
	public float pickUpDist = 5f;
	public int ammoToAdd = 25;

	// Update is called once per frame
	void Update ()
	{
		if ((transform.position - playerLocation.position).magnitude <= pickUpDist) {
			playerAmmo.ammo += ammoToAdd;
			gameObject.SetActive (false);
		}
	}
}
