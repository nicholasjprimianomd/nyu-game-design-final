using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Lifetime;

public class BulletExpire : MonoBehaviour
{
	
	private float initalTime;
	public float lifeTime = 2;

	// Use this for initialization
	void Start ()
	{
		initalTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time - initalTime > lifeTime || GetComponent<Rigidbody2D> ().velocity.magnitude < 1) {
			Destroy (gameObject);
		}

	}
}