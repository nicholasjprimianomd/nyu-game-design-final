using UnityEngine;
using System.Collections;

public class RealRoombaRaycast : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
     
        RaycastHit2D roombahit = Physics2D.Raycast(transform.position, transform.up, 0.4f); //shoots raycast

        if (roombahit.collider != null) { //if raycast hits something 
            float randomNumber = Random.Range(0f, 1f); //turn randomly 90 degreees left or right
            if ( randomNumber > 0.5f )
            {
                transform.Rotate(0f, 0f, 90f);
            } else
            {
                transform.Rotate(0f, 0f, -90f);
            }

        

        }
        else //if raycast hits nothing, always go forward
        {
            transform.position += transform.up * Time.deltaTime;
        }
    }
}
