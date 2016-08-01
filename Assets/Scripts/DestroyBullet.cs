using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour
{

	void Update ()
	{
		if (GetComponent<Rigidbody2D> ().velocity.magnitude < 1f) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{

		Destroy (gameObject);
		
	}
}
