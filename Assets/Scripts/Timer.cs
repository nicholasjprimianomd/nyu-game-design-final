using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq.Expressions;
using System;


public class Timer : MonoBehaviour
{

	//public GameObject playerWin;
	static Timer instance = null;
	GUIStyle font;
	GUIStyle fontSmall;
	public float timer = 0;
	//private Treasure win;
	private Scene scene;
	//private bool failUITime = false;
	public float score = 0;

	void Start ()
	{
		//win = playerWin.GetComponent<Treasure> ();
		scene = SceneManager.GetActiveScene ();

		if (instance != null) {
			Destroy (gameObject);

		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	
		font = new GUIStyle ();
		font.fontSize = 36;
		font.normal.textColor = Color.white;
		fontSmall = new GUIStyle ();
		fontSmall.fontSize = 20;
		fontSmall.normal.textColor = Color.white;
	}

	void Update ()
	{
		if (scene.name == "Game") {
			timer += Time.deltaTime;
		}

		scene = SceneManager.GetActiveScene ();
	}

	void OnGUI ()
	{
		int minutes = Mathf.FloorToInt (timer / 60f);
		int seconds = Mathf.FloorToInt (timer - minutes * 60);
		string time = string.Format ("{0:00}:{1:00}", minutes, seconds);
		float timeScore = Mathf.FloorToInt (timer);
		timeScore += score;

		if (scene.name == "Game") {
			GUI.Box (new Rect (10, 10, 125, 25), "Game Timer : " + time, fontSmall);
			GUI.Box (new Rect (10, 35, 125, 25), "Score : " + timeScore.ToString (), fontSmall);
		} else {
			GUI.Label (new Rect (400, 280, 125, 200), "Game Timer : " + time, font);
			GUI.Label (new Rect (450, 330, 125, 200), "Score : " + timeScore.ToString (), font);
		}
		//} else if (win.playerWin && !failUITime) {
		//	GUI.Label (new Rect (709, 341, 125, 200), time, font);
		//Debug.Log (failUITime);
		//} else if (win.playerWin && failUITime) {
		//	GUI.Label (new Rect (709, 341, 125, 200), time + " (Fail Mode)", font);
		//}
	}
}
