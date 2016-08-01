using UnityEngine;
using System.Collections;

public class DestroyGrapple : MonoBehaviour
{

	private GameObject player;
	private float initalTime;
	public float lifeTime = 4;

	// Use this for initialization
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		initalTime = Time.time;
	}




	
	// Update is called once per frame
	void Update ()
	{
		if ((transform.position - player.transform.position).magnitude > 10) {
			Destroy (gameObject);
		}
		if (Time.time - initalTime > lifeTime) {
			Destroy (gameObject);
		}
	}
}
