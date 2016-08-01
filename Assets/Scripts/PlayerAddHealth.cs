using UnityEngine;
using System.Collections;
using System;

public class PlayerAddHealth : MonoBehaviour
{
	public Transform playerLocation;
	public PlayerTakeDamage playerHealth;
	public float pickUpDist = 5f;
	public int healthToAdd = 25;
	
	// Update is called once per frame
	void Update ()
	{
		if ((transform.position - playerLocation.position).magnitude <= pickUpDist && playerHealth.currentHealth < playerHealth.maxHealth) {
			playerHealth.currentHealth += healthToAdd;
			gameObject.SetActive (false);
		}
	}
}
