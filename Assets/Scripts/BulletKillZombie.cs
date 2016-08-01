using UnityEngine;
using System.Collections;

public class BulletKillZombie : MonoBehaviour
{
	GameObject score;
	Timer gameScore;

	void Update ()
	{
		score = GameObject.FindWithTag ("Timer");
		gameScore = score.GetComponent<Timer> ();
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Zombie") {
			gameScore.score = gameScore.score + 5;
			//Debug.Log (gameScore);
			Destroy (coll.gameObject);
			Destroy (gameObject);
		}

	}
}
