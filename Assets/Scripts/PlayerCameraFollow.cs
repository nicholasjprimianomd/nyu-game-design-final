using UnityEngine;
using System.Collections;

public class PlayerCameraFollow : MonoBehaviour
{

	public Vector3 offset;

	void Update ()
	{
		Camera.main.transform.position = transform.position + offset;
	}

}
