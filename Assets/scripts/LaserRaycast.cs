//using UnityEngine;
//using System.Collections;
//
//public class LaserRaycast : MonoBehaviour {
//
//    public GameObject laserbeamObject;
//
//	void Start () {
//		InvokeRepeating (LaserBeam, 1, 2);
//
//	}
//
//	// Update is called once per frame
//	void Update () {
//        transform.Rotate (0f, 0f, -Input.GetAxis("Horizontal") * Time.deltaTime * 90f);
//
//	}
////
////		void LaserBeam () {
////            laserbeamObject.SetActive(true);
////
////            RaycastHit2D raycastHit = Physics2D.Raycast( transform.position, transform.up, 50f );
////            //checks results of raycast
////            if ( raycastHit.collider != null )
////            {
////                Destroy(raycastHit.collider.gameObject); 
////            }
//        
//
////        else
////        {
////            laserbeamObject.SetActive(false);
////        }
//	}
//}