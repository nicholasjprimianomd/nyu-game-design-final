using UnityEngine;
using System.Collections;

public class ArrowMove : MonoBehaviour {

	GameObject player;
	Vector2 arrowMoves = new Vector2 (0f, 0f);
	Rigidbody2D myRigidbody; // Opens a Rigidbody for the bullet
	public int arrowSpeed;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		player = GameObject.FindWithTag("Player");

		Vector3 playerPosition = player.transform.position;
		transform.position = playerPosition;
		Vector3 playerDirection = player.transform.up;
		arrowMoves = playerDirection;
	}

	void FixedUpdate () {
		myRigidbody.velocity = arrowMoves * arrowSpeed;
	}

}