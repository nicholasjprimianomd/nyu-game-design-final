using UnityEngine;
using System.Collections;

public class ZombieMove : MonoBehaviour
{
	private Transform destination;
	public float zombieMoveSpeed = 2;
	public bool canMove = true;
	public bool stun;
	private bool stunTimerCount;
	private float stunTimer;

	void Start ()
	{
		canMove = true;
		stunTimerCount = true;
	}


	void Update ()
	{
		destination = GameObject.FindGameObjectWithTag ("Player").transform;

		if (Vector3.Distance (transform.position, destination.position) > 1f && canMove && !stun) {
			transform.position += Vector3.Normalize (destination.position - transform.position) * Time.deltaTime * zombieMoveSpeed;
		}
	
		if (stun) {
			if (stunTimerCount) {
				stunTimer = Time.time;
				stunTimerCount = false;
			}	

			if (Time.time - stunTimer > 3) {
				stun = false;
				stunTimerCount = true;
			}
		}
		
	}
}
