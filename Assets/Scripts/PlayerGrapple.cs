using UnityEngine;
using System.Collections;

public class PlayerGrapple : MonoBehaviour {

	public GameObject bullet;
	public Transform spawnPoint;
	public float xOffset = 0;
	public float yOffset = 1;
	public float bulletSpeed = 25;

	void Update ()
	{
		shoot ();
	}

	void shoot ()
	{
		if (Input.GetKeyDown(KeyCode.E)) {
			Vector2 bulletDirection = (spawnPoint.position - transform.position).normalized;
			GameObject bulletPrefab = Instantiate (bullet, spawnPoint.position, transform.rotation) as GameObject;
			Rigidbody2D bulletRigidBody2D = bulletPrefab.GetComponent<Rigidbody2D> ();
			bulletRigidBody2D.AddForce (bulletDirection * bulletSpeed, ForceMode2D.Impulse);
		}
	}
		
}
