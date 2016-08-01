using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed = 5f;
	private float moveFast;
	Vector2 moveVector = new Vector2 (0f, 0f);
	Rigidbody2D myRigidbody;

	void Start ()
	{
		moveFast = moveSpeed * 1.5f;
		myRigidbody = GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void Update ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		moveVector = new Vector2 (horizontal, vertical);
		if (moveVector.magnitude > 1f) {
			moveVector = moveVector.normalized; // better way of normalization
		}
			
		Vector3 cursorPositionInWorld = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		cursorPositionInWorld.z = 0;

		Vector3 point = cursorPositionInWorld - transform.position;
		transform.up = point;
	
		currentTime = Time.time;

		/*
		if (!fireIsCounting) {
			startTimeFireShield = currentTime;
		}

		if (Input.GetKeyDown (KeyCode.E) && numFireShields > 0 && (currentTime - startTimeFireShield <= fireSheildTime) && !shieldActive) {
			fireShield ();
			numFireShields = numFireShields - 1;
		}

		//hack 
		if (numFireShields == 2) {
			shield1.SetActive (false);
		} else if (numFireShields == 1) {
			shield2.SetActive (false);
		} else if (numFireShields == 0) {
			shield3.SetActive (false);
		}	

		if (currentTime - startTimeFireShield > fireSheildTime) {
			fireIsCounting = false;
			immumeFire = false;
			shieldActive = false;
		}
*/


		//Sprint Code
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			initialTime = Time.time;

			//button logic
			//buttonUp.SetActive (true);
			//buttonUp.SetActive (false);
			//inputStart = true;
		}

		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			counting = false;
			canSprint = false;

			//button logic
			//buttonUp.SetActive (false);
			//buttonUp.SetActive (true);

		}

		if (counting && (currentTime - initialTime) >= maxSprintTime) {
			canSprint = false;
		}

		if (currentTime - coolDownTimer >= coolDown) {
			canSprint = true;
			//boost.gameObject.SetActive (true);
			//counter.gameObject.SetActive (false);
		} /*else if (!inputStart) {
			boost.gameObject.SetActive (true);
			counter.gameObject.SetActive (false);
		} else {
			float temp;
			boost.gameObject.SetActive (false);
			counter.gameObject.SetActive (true);
			temp = Mathf.Ceil (currentTime - coolDownTimer);
			//Very ugly hack TO count backwards can't change CD time
			if (temp == 1) {
				counter.text = "4";
			} else if (temp == 2) {
				counter.text = "3";
			} else if (temp == 3) {
				counter.text = "2";
			} else if (temp == 4) {
				counter.text = "1";
			}

		}*/

		if (Input.GetKeyDown (KeyCode.LeftShift) && canSprint) {
			coolDownTimer = Time.time;
		}

		//Debug.Log (canSprint);
		if (Input.GetKey (KeyCode.LeftShift) && canSprint) {
			counting = true;
			//attach red trail renderer to player
			//why is unity terrible there should be a class for this
			//trailRendererRed.transform.parent = transform;
			//trailRendererRed.transform.position = transform.position;
			//trailRendererGreen.enabled = false;
			//trailRendererRed.enabled = true;
			moveSpeed = moveFast;
		} else {
			//trailRendererGreen.enabled = true;
			//trailRendererRed.enabled = false;
			moveSpeed = 5f;
		}
	
	}


	//private float playerSpeedSet = 15;
	//private float shiftSpeed = 25;
	//private float playerSpeed;

	private float initialTime;
	private bool canSprint = true;
	private const float maxSprintTime = 2f;
	private const float coolDown = 4f;
	private bool counting = false;
	private float coolDownTimer;
	//public GameObject buttonUp;
	//public GameObject buttonDown;
	//public Text boost;
	//public Text counter;
	//private bool inputStart = false;
	//public int numFireShields = 3;
	//public bool immumeFire = false;
	//public float fireSheildTime = 2f;

	private float currentTime;

	//float startTimeFireShield;
	//bool fireIsCounting = false;

	//public GameObject shield1;
	//public GameObject shield2;
	//public GameObject shield3;
	//public GameObject shield4;
	//private bool shieldActive = false;


	// Better practice to initalize a GetComponent<>() in start
	//void Start ()
	//{
	//playerSpeed = playerSpeedSet;
	//myRigidbody = GetComponent<Rigidbody2D> ();

	//boost.gameObject.SetActive (true);
	//counter.gameObject.SetActive (false);

	//	}


	/*void fireShield ()
	{
		fireIsCounting = true;
		immumeFire = true;
		shieldActive = true;

	}
    */

	// FixedUpdate is when Physics runs
	void FixedUpdate ()
	{
		myRigidbody.velocity = moveVector * moveSpeed;
	}

}










