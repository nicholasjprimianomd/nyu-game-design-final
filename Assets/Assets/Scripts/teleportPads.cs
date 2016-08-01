using UnityEngine;
using System.Collections;

public class teleportPads : MonoBehaviour {
	public GameObject partner;
	public Vector3 newLocation;

	void Start(){
		//Vector3 newLocation = partner.transform.position;
	}

	void Update(){
		
		Vector3 newLocation = partner.transform.position;
		if (partner.transform.position == null) {
			Debug.Log ("Null");
		}
	}

	void OnTriggerEnter2D( Collider2D activator){
		if (activator.GetComponent<teleportable> () != null) {
			activator.transform.position = newLocation;
		}

	}
}
