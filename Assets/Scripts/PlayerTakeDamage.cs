using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEditor;

public class PlayerTakeDamage : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth = 100;
	public float maxShield = 5;
	public float shieldRegenRate = 1;
	public float currentShield = 100;

	void Update ()
	{
		if (currentHealth >= maxHealth) {
			currentHealth = maxHealth;
		}

		if (currentShield >= maxShield) {
			currentShield = maxShield;
		}
			

		if (currentHealth <= 0) {
			SceneManager.LoadScene ("Death Scene");
		}

		incShield ();
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Zombie") {
			print ("1");
			if (currentShield > 0) {
				currentShield -= 1;
				print ("2");
			} else {
				currentHealth -= 1;
				print ("3");
			}
		}
	}

	void incShield ()
	{
		currentShield += 1f * Time.deltaTime * shieldRegenRate;
	}
}
