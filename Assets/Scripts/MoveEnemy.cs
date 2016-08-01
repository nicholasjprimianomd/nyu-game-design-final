using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	private Vector3 pointA;
	public Vector3 pointB;
	public bool enemyCanMove;


 IEnumerator Start()

	  {
		enemyCanMove = true;
		pointA = transform.position;

		while(true)
		{
				yield return StartCoroutine (MoveObject (transform, pointA, pointB, 3.0f));
				yield return StartCoroutine (MoveObject (transform, pointB, pointA, 3.0f));
		}
 }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
   {
		
	  	 float i = 0.0f;
		 float rate = 1.0f/time;
		 while(i < 1.0f)
		 {
			if (enemyCanMove) {
			 i += Time.deltaTime * rate;
	  		 thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			  yield return null; 
			} else{
				yield return new WaitForSeconds (.5f);
			}
		}
				

			
	}		
}
