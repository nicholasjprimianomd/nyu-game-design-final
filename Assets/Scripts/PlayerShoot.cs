using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.Rendering;


public class PlayerShoot : MonoBehaviour
{

	public GameObject bullet;
	public GameObject burstBullet;
	public Transform spawnPoint;
	public Transform spawnPointLeft;
	public Transform spawnPointRight;
	public float xOffset = 0;
	public float yOffset = 1;
	public float bulletSpeed;
	public bool canShoot = true;
	public int rounds = 8;
	public int ammo = 16;
	private const int maxRounds = 8;

	private float currentTime;

	private bool offCoolDown;
	private float coolDown;
	public float shootCoolDown = .5f;

	private bool burstOffCoolDown;
	private float burstCoolDown;
	public float burstCoolDownTime = 2f;

	void Start ()
	{
		offCoolDown = true;
		burstOffCoolDown = true;
	}

	void Update ()
	{

		currentTime = Time.time;

		if (currentTime - coolDown > shootCoolDown) {
			offCoolDown = true;
		}

		if (currentTime - burstCoolDown > burstCoolDownTime) {
			burstOffCoolDown = true;
		}

		if (Input.GetKeyDown (KeyCode.R) && ammo > 0) {
			reload ();
		}

		if (canShoot && rounds > 0 && offCoolDown) {
			shoot ();
		}

		if (canShoot && rounds > 0 && burstOffCoolDown) {
			shootBurst ();
		}
	}

	void shoot ()
	{
		if (!Input.GetMouseButtonDown (1) && Input.GetMouseButtonDown (0)) {
			Vector2 bulletDirection = (spawnPoint.position - transform.position).normalized;
			GameObject bulletPrefab = Instantiate (bullet, spawnPoint.position, transform.rotation) as GameObject;
			Rigidbody2D bulletRigidBody2D = bulletPrefab.GetComponent<Rigidbody2D> ();
			bulletRigidBody2D.AddForce (bulletDirection * bulletSpeed, ForceMode2D.Impulse);

			offCoolDown = false;
			coolDown = Time.time;
			rounds -= 1;
		}
	}


	void shootBurst ()
	{
		if (Input.GetMouseButtonDown (1) && !Input.GetMouseButtonDown (0)) {
			Vector2 bulletDirection = (spawnPointLeft.position - transform.position).normalized;
			GameObject bulletPrefab = Instantiate (burstBullet, spawnPointLeft.position, transform.rotation) as GameObject;
			Rigidbody2D bulletRigidBody2D = bulletPrefab.GetComponent<Rigidbody2D> ();
			bulletRigidBody2D.AddForce (bulletDirection * bulletSpeed, ForceMode2D.Impulse);
			rounds -= 1;

			if (rounds > 0) {
				Vector2 bulletDirection2 = (spawnPoint.position - transform.position).normalized;
				GameObject bulletPrefab2 = Instantiate (burstBullet, spawnPoint.position, transform.rotation) as GameObject;
				Rigidbody2D bulletRigidBody2D2 = bulletPrefab2.GetComponent<Rigidbody2D> ();
				bulletRigidBody2D2.AddForce (bulletDirection2 * bulletSpeed, ForceMode2D.Impulse);
				rounds -= 1;
			}

			if (rounds > 0) {
				Vector2 bulletDirection3 = (spawnPointRight.position - transform.position).normalized;
				GameObject bulletPrefab3 = Instantiate (burstBullet, spawnPointRight.position, transform.rotation) as GameObject;
				Rigidbody2D bulletRigidBody2D3 = bulletPrefab3.GetComponent<Rigidbody2D> ();
				bulletRigidBody2D3.AddForce (bulletDirection3 * bulletSpeed, ForceMode2D.Impulse);
				rounds -= 1;
			}

			burstOffCoolDown = false;
			burstCoolDown = Time.time;
		}
	}



	void reload ()
	{
		int roundDeficit = maxRounds - rounds;

		if (roundDeficit >= 0) {
			rounds += roundDeficit;
			while (ammo > 0 && roundDeficit > 0) {
				ammo -= 1;
				roundDeficit -= 1;
			}
		}
	}

}
