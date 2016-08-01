using UnityEngine;
using System.Collections;
using System.Net;

public class SpawnZombie : MonoBehaviour
{

	public GameObject zombie;
	public GameObject player;
	public float offsetRange = 5;
	public float spawnTimer = 2f;

	void spawnZombie ()
	{
		float offset = Random.Range (-offsetRange - 75, offsetRange + 75);
		Vector3 zombeSpawnLocation = new Vector3 (player.transform.position.x + offset, player.transform.position.y + offset, player.transform.position.z);
		Instantiate (zombie, zombeSpawnLocation, Quaternion.identity);
	}

	void Start ()
	{
		InvokeRepeating ("spawnZombie", 1f, spawnTimer);
	}

		
}
