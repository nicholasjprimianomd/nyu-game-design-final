using UnityEngine;
using System.Collections;

public class Grapple : MonoBehaviour {

	private Transform startMarker;
	private Transform endMarker;
	public float speed = .5F;
	private GameObject player;
	private GameObject enemy;
	private bool isLerping = false;
	private bool isWall = false;
	private bool isEnemy = false;
	private bool canCollide;
	private MoveEnemy movingEnemy;

	void Awake() {
		canCollide = true;
	}

	void Update() {
		player = GameObject.FindGameObjectWithTag ("Player");

		if (isLerping && isWall) {
			player.transform.position = Vector3.MoveTowards (startMarker.position, endMarker.position, .5f);
			if(player.transform.position == endMarker.position){
				isLerping = false;
				isWall = false;
				gameObject.SetActive (false);
			}
		}

		if (isLerping && isEnemy) {
			enemy.transform.position = Vector3.MoveTowards (enemy.transform.position, player.transform.position, .15f);
			if(Vector3.Distance (enemy.transform.position, player.transform.position) < 1f){
				isLerping = false;
				isEnemy = false;
				//Check for following zombie
				if (enemy.GetComponent<ZombieMove> () != null) {
					enemy.GetComponent<ZombieMove> ().canMove = true;
				}

				//Start static moving Zombie again
				if(movingEnemy!= null){
					movingEnemy.enemyCanMove = true;
				}

				gameObject.SetActive (false);
			}
		}
	}
		
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (canCollide) {
			if (coll.gameObject.tag == "Wall") {
				startMarker = player.transform;
				endMarker = transform;
				isLerping = true;
				isWall = true;
				canCollide = false;
			}

			if (coll.gameObject.tag == "Zombie") {
				//Check for static moving zombie
				if(coll.gameObject.GetComponent<MoveEnemy>() != null){
					movingEnemy = coll.gameObject.GetComponent<MoveEnemy> ();
					movingEnemy.enemyCanMove = false;
				}

				enemy = coll.gameObject;
				isLerping = true;
				isEnemy = true;

				//Check for following zombie
				if (enemy.GetComponent<ZombieMove> () != null) {
					enemy.GetComponent<ZombieMove> ().canMove = false;
				}

				canCollide = false;
			}
		}
	}
}
