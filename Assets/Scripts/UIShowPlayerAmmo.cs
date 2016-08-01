using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIShowPlayerAmmo : MonoBehaviour
{
	public PlayerShoot player;
	private Text ammoText;

	void Start ()
	{
		ammoText = GetComponent<Text> ();
	}

	void Update ()
	{
		ammoText.text = "Ammo : " + player.rounds.ToString () + " / " + player.ammo.ToString ();
	}
}
