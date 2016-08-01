using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	Vector2 moveVector = new Vector2(0f,0f);
	Rigidbody2D myRigidbody;
	public float speed = 5f;
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		moveVector = new Vector2 (horizontal, vertical);
		if (moveVector.magnitude > 1f) {
			moveVector = moveVector.normalized;
		}

	}

	void FixedUpdate(){
		//myRigidbody.velocity= new Vector2(0f,0f);
		//= Vector2.zero

		myRigidbody.velocity= moveVector*speed;

	}

}
