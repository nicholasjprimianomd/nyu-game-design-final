using UnityEngine;
using System.Collections;

public class SpriteChange : MonoBehaviour {

	public Sprite whiteSword;
	public Sprite harp;
	public Sprite clawShots;
	public Sprite whip;
	public Sprite bowArrow;

	SpriteRenderer renderSprite;

	public Transform player;
	public GameObject theArrow;

	bool isbowArrow = false;

	void Start () {
		renderSprite = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
	
		Vector3 cursorPosInWorld = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		cursorPosInWorld.z = 0f; 
		player.transform.up = cursorPosInWorld - player.transform.position;


		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			renderSprite.sprite = whiteSword;
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			renderSprite.sprite = bowArrow;
			isbowArrow = true;
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			renderSprite.sprite = harp;
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			renderSprite.sprite = whip;
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			renderSprite.sprite = clawShots;
		} else if ((isbowArrow == true) && (Input.GetMouseButtonDown (0)) ) {
			Debug.Log ("it's the bow and arrow!");
			Instantiate (theArrow, player.position, Quaternion.Euler (0f, 0f, 0f));
		}

	}

}
